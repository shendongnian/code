    private string ShellCommand(string command)  
    {
      var psi = new ProcessStartInfo("cmd", "/c " + command) {
        RedirectStandardOutput = true,
        CreateNoWindow = true
      };
      var p = Process.Start(psi);
      return p.StandardOutput.ReadToEnd();
    }
    private string FindDefaultProgram(string extension)
    {
       assoc = ShellCommand("assoc " + extension).Split('=')[1];
       program = ShellCommand("ftype " + assoc).Split('=')[1];
       return program;
    }
