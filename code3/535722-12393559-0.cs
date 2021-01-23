    ProcessStartInfo psi = new ProcessStartInfo("jconsole.exe");
    StringDictionary dictionary = psi.EnvironmentVariables;
    // Manipulate dictionary...
    psi.EnvironmentVariables["PATH"] = dictionary.Replace(@"\\", @"\");
    Process.Start(psi);
