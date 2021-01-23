    protected void Get_Mailboxes(object sender, EventArgs e) {
      var commandResults = ps.ClearCommands().AddCommand("Get-Mailbox").Invoke();
      StringBuilder sb = new StringBuilder();
      ArrayList boxesarray = new ArrayList();
      foreach (PSObject ps in commandResults)
      {
          boxesarray.Add(ps.Properties["Alias"].Value.ToString());
      }
      boxes.DataSource = boxesarray;
      boxes.DataBind();
    }
