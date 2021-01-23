    //UCM.WFDesigner is my assembly name, 
    //Resources.Flows is the folder name, 
    //and DefaultFlow.xaml is the xaml name. 
     private const string ConstDefaultFlowFullName = @"UCM.WFDesigner.Resources.Flows.DefaultFlow.xaml";
          private void CreateNewWorkflow(object param)
        {
                   
            //loading default activity embeded resource
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ConstDefaultFlowFullName))
            {
                StreamReader sReader = new StreamReader(stream);
                string content = sReader.ReadToEnd();
                //createion ActivityBuilder from string
                ActivityBuilder activityBuilder = XamlServices.Load( ActivityXamlServices
                    .CreateBuilderReader(new XamlXmlReader(new StringReader(content)))) as ActivityBuilder;
                //loading new ActivityBuilder to Workflow Designer
                _workflowDesigner.Load(activityBuilder);
                OnPropertyChanged("View");
            }
        }
