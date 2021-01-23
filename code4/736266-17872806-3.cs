    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e) 
        { 
              if(Session["UserName"]!=null)
               {
               // do this only when Session Variable stores as a string the Username
               e.Command.Parameters["@Username"].Value = Session["UserName"];
               }
             else
               {
                  // assign the default value if session variable is Null
                  e.Command.Parameters["@Username"].Value ="DefaultValue";
                }
        
        }
