    protected void LookupButton_Click( object sender, EventArgs e ) {
      string outp = "";
      WindowsIdentity wid = IdentityHelper.Logon(Request["AUTH_USER"], Request["AUTH_PASSWORD"]);
      using( wid.Impersonate() ) {
        Runspace runspace;
        Pipeline pipe;
        try {
          runspace = PSHelper.new_runspace();
          runspace.Open();
          pipe = runspace.CreatePipeline();
          Command cmd = new Command("Get-ADUser");
          cmd.Parameters.Add(new CommandParameter("Identity", text_username.Text));
          pipe.Commands.Add(cmd);
          outp = pipe.Invoke().First().Properties["Name"].Value.ToString();
        }
        catch( Exception ex ) {
          outp += "Exception Caught:";
          outp += ex.ToString();
        }
      }
      output.Text = outp;
    }
