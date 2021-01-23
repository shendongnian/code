    public ServiceHost[] serviceHost = null;
        public MyService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {            
            try
            {
                //Get path for the executing assemblly
                string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //Path to the dlls to be hosted
                string filePath = exePath + "\\DLLsToHost\\";
                //Retrieve only dll files from the folder
                string[] files = Directory.GetFiles(@filePath, "*.dll");
                //get the dll file names
                for (int i = 0; i < files.Length; i++)
                    files[i] = Path.GetFileName(files[i]);
                
                //create an array of ServiceHost type
                serviceHost = new ServiceHost[files.Length];
                //get the base address for the services from config file
                string address = ConfigurationManager.AppSettings["baseAddress"];
                int j = 0;
                foreach (var dllName in files)
                {
                    string dllPath = filePath + dllName;
                    //Load the dll
                    Assembly assembly = Assembly.LoadFrom(@dllPath);
                    //Get the class name implementing the service
                    string serviceName = ConfigurationManager.AppSettings[dllName];
                    //get the interface name implemented by the class
                    string interfaceName = ConfigurationManager.AppSettings["I" + dllName];
                    if (serviceName == null || interfaceName == null)
                    {
                        Logging.trace(System.Diagnostics.TraceLevel.Error,
                            "Configuration settings for " + dllName + " are not proper. "+
                            "The name of the class implementing the service should be defined with the key value as '"+dllName+"' and" +
                        "The name of the interface should be defined with the key value as 'I"+dllName+"'.", "OnStart()");
                    }
                    else
                    {
                        //Get the class implementing the service
                        Type service = assembly.GetType(serviceName);
                        if (service != null)
                        {
                            //Get the interface implemented by the class
                            Type contract = service.GetInterface(interfaceName, true);
                            if (contract != null)
                            {
                                //Create a base address for the service
                                Uri baseAddress = new Uri(address + dllName.Remove(dllName.LastIndexOf(".")));
                                if (serviceHost[j] != null)
                                {
                                    serviceHost[j].Close();
                                }
                                serviceHost[j] = new CustomServiceHost(service, baseAddress);
                                //add the service endpoint and contract
                                ServiceEndpoint sEP = serviceHost[j].AddServiceEndpoint(contract, new WebHttpBinding(), "");
                                WebHttpBehavior webHttpBeh = sEP.Behaviors.Find<WebHttpBehavior>();
                                //Set the service and endpoint behaviours
                                if (webHttpBeh != null)
                                {
                                    webHttpBeh.AutomaticFormatSelectionEnabled = true;
                                    webHttpBeh.DefaultOutgoingResponseFormat = WebMessageFormat.Json;
                                    webHttpBeh.HelpEnabled = true;
                                    sEP.Behaviors.Add(new BehaviorAttribute());     //Add CORS support
                                }
                                else
                                {
                                    WebHttpBehavior newWebHttpBeh = new WebHttpBehavior();
                                    newWebHttpBeh.AutomaticFormatSelectionEnabled = true;
                                    newWebHttpBeh.DefaultOutgoingResponseFormat = WebMessageFormat.Json;
                                    newWebHttpBeh.HelpEnabled = true;
                                    sEP.Behaviors.Add(newWebHttpBeh);
                                    sEP.Behaviors.Add(new BehaviorAttribute());     //Add CORS support
                                }
                                serviceHost[j].Open();
                            }
                            else
                            {
                                Logging.trace(System.Diagnostics.TraceLevel.Error,
                            "Could not load the interface '" + interfaceName + "' for " + dllName, "OnStart()");
                            }
                        }
                        else
                        {
                            Logging.trace(System.Diagnostics.TraceLevel.Error,
                            "Could not load the class '" +serviceName+ "' that implement the service for " + dllName, "OnStart()");
                        }
                    }
                    j++;
                }
            }
            catch(Exception ex)
            {
                Logging.trace(System.Diagnostics.TraceLevel.Error, ex.Message, "OnStart()");
            }
        }
        protected override void OnStop()
        {
            try
            {
                for (int k = 0; k <= serviceHost.Length - 1; k++)
                {
                    if (serviceHost[k] != null)
                    {
                        serviceHost[k].Close();
                        serviceHost[k] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.trace(System.Diagnostics.TraceLevel.Error, ex.Message, "OnStop()");
            }
        }
    }
