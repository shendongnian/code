        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Anzeigen")
            {
                string sID = e.CommandArgument.ToString();
                int id = 0;
                int.TryParse(sID, out id);
                if (id > 0)
                { 
                 // do stuff
                }
            }
        }
