      foreach (Control ctr in Page.Form.Controls)
            {
                if (ctr.GetType() == typeof(System.Web.UI.ScriptManager))
                {
                    Page.Form.Controls.Remove(ctr);
                    break;
                }
            }
         if (ScriptManager.GetCurrent(this.Page) == null)
             {
                 ScriptManager scriptManager = new ScriptManager();
                 scriptManager .ID = "scriptManager" + RandomNo;
                 Page.Form.Controls.AddAt(0, scriptManager );
             }
