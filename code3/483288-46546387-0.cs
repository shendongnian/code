    If Not New WindowsPrincipal(WindowsIdentity.GetCurrent).IsInRole(WindowsBuiltInRole.Administrator) Then
                Process.Start(New ProcessStartInfo With { _
                                                         .UseShellExecute = True, _
                                                         .WorkingDirectory = Environment.CurrentDirectory, _
                                                         .FileName = Assembly.GetEntryAssembly.CodeBase, _
                                                         .Verb = "runas"})
