    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    
    namespace MatemanSC.Utility
    {
        public class ClickOnceUtil
        {
            Version _UpdateVersion = null;
            public string UpdateLocation
            {
                get
                {
                    return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.UpdateLocation.AbsoluteUri;
                }
            }
            public Version AvailableVersion
            {
                get
                {
                    if (_UpdateVersion == null)
                    {
                        _UpdateVersion = new Version("0.0.0.0");
                        if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                        {
                            using (XmlReader reader = XmlReader.Create(System.Deployment.Application.ApplicationDeployment.CurrentDeployment.UpdateLocation.AbsoluteUri))
                            {
                                //Keep reading until there are no more FieldRef elements
                                while (reader.ReadToFollowing("assemblyIdentity"))
                                {
                                    //Extract the value of the Name attribute
                                    string versie = reader.GetAttribute("version");
                                    _UpdateVersion = new Version(versie);
                                }
                            }
                        }
                    }
                    return _UpdateVersion;
                }
            }
            public bool UpdateAvailable
            {
                get
                {
                    return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion != AvailableVersion;
                }
            }
            public string CurrentVersion
            {
                get
                {
                    return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
            }
    
            public void Update()
            {
                System.Diagnostics.Process.Start(System.Deployment.Application.ApplicationDeployment.CurrentDeployment.UpdateLocation.AbsoluteUri);
                Environment.Exit(0);
            }
    
            public void CheckAndUpdate()
            {
                try
                {
                    if (UpdateAvailable)
                        Update();
                }
                catch (Exception)
                {
                }
            }
        }
    }
 
