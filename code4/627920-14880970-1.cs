    void CommandBtn_Click(Object sender, CommandEventArgs e) 
          {
    
             if((string.Compare(e.CommandName, "yourCommandName", false)==0)
             {
                   YourMethodAcceptingTheIdAsParameter((int)e.CommandArgument);            
             }
          }
