    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Linq;
    using Microsoft.VisualStudio.Tools.Applications;
    using Microsoft.VisualStudio.Tools.Applications.Runtime;
    using System.IO;
    using System.Windows.Forms;
    
    namespace AddCustomizationCustomAction
    {
        [RunInstaller(true)]
        public partial class AddCustomization : System.Configuration.Install.Installer
        {
            //Note: you'll have to get the Guid from your specific project in order for it to work.  The MSDN article show you how.
            static readonly Guid SolutionID = new Guid("20cb4d1d-3d14-43c9-93a8-7ebf98f50da5");
    
            public override void Install(IDictionary stateSaver)
            {
                string[] nonpublicCachedDataMembers = null;
    
    
                // Use the following for debugging during the install
                //string parameters = "Parameters in Context.Paramters:";
                //foreach (DictionaryEntry parameter in Context.Parameters)
                //{
                //    parameters = parameters + "\n" + parameter.Key + ":" + parameter.Value;
                //}
    
                //MessageBox.Show(parameters);
    
                //MessageBox.Show("total items in parameters: " + Context.Parameters.Count);
                //MessageBox.Show("Document Manifest Location:" + Context.Parameters["deploymentManifestLocation"]);
    
                Uri deploymentManifestLocation = null;
                if (Uri.TryCreate(
                    Context.Parameters["deploymentManifestLocation"],
                    UriKind.RelativeOrAbsolute,
                    out deploymentManifestLocation) == false)
                {
                    throw new InstallException(
                        "The location of the deployment manifest " +
                        "is missing or invalid.");
                }
                string documentLocation =
                    Context.Parameters["documentLocation"];
                if (String.IsNullOrEmpty(documentLocation))
                {
                    throw new InstallException(
                        "The location of the document is missing.");
                }
                string assemblyLocation =
                    Context.Parameters["assemblyLocation"];
                if (String.IsNullOrEmpty(assemblyLocation))
                {
                    throw new InstallException(
                        "The location of the assembly is missing.");
                }
    
                // use the following for debugging
                MessageBox.Show(documentLocation);
    
                if (ServerDocument.IsCustomized(documentLocation))
                {
                    ServerDocument.RemoveCustomization(documentLocation);
                }
                ServerDocument.AddCustomization(
                    documentLocation,
                    assemblyLocation,
                    SolutionID,
                    deploymentManifestLocation,
                    false,
                    out nonpublicCachedDataMembers);
                stateSaver.Add("documentlocation", documentLocation);
                base.Install(stateSaver);
            }
    
            public override void Commit(IDictionary savedState)
            {
                base.Commit(savedState);
            }
    
            public override void Rollback(IDictionary savedState)
            {
                base.Rollback(savedState);
            }
    
            public override void Uninstall(IDictionary savedState)
            {
                base.Uninstall(savedState);
            }
    
        }
    }
