    private PSObject _ps_user_lookup( string id_param ) {
      Runspace runspace = PSHelper.new_runspace();
      runspace.Open();
      using( Pipeline pipe = runspace.CreatePipeline() ) {
        Command cmd = new Command("Get-ADUser");
        cmd.Parameters.Add(new CommandParameter("Identity", id_param));
        cmd.Parameters.Add(new CommandParameter("Properties", "*"));
        cmd.Parameters.Add(new CommandParameter("Server", "REDACTED"));
        pipe.Commands.Add(cmd);
        return pipe.Invoke().FirstOrDefault();
      }
    }
