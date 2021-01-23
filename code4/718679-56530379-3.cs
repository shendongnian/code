    // Load localization.ini
    LineRoot.Builder.AddLocalizationFile("localization.ini").Build();
    // Create key for enum
    ILine key = LineRoot.Global.Assembly("ConsoleApp4").Type<Permissions>().Format("{0}");
    // Print 
    Console.WriteLine(key.Value(Permissions.Create | Permissions.Drop));
    Console.WriteLine(key.Value(Permissions.Create | Permissions.Drop).Culture("en"));
    Console.WriteLine(key.Value(Permissions.Create | Permissions.Drop).Culture("fi"));
