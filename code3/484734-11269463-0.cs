    XamlReader xamlReader;
    //Assembly wfAssembly = Assembly.GetExecutingAssembly();
    Assembly wfAssembly = Assembly.LoadFile(@"Workflows.dll");
    XamlXmlReaderSettings settings = new XamlXmlReaderSettings();
    settings.LocalAssembly = wfAssembly;
    xamlReader = new XamlXmlReader(@"Workflow.xaml", settings);
    Activity wf = ActivityXamlServices.Load(xamlReader);
