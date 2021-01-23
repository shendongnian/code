    private void menuActive(ToolStripItemCollection items) 
        { 
            hp.getConnStr(); 
            MySqlConnection connection = new MySqlConnection(hp.myConnStr); 
            MySqlCommand command = connection.CreateCommand(); 
            MySqlDataReader Reader; 
            command.CommandText = "select menu_key from mcs_menu_rights where userid ='"+userId+"'"; 
            connection.Open(); 
            Reader = command.ExecuteReader(); 
            while (Reader.Read()) 
            {
                var nameFromDB = Reader[0].ToString();
                setMenuActiveByName(items, nameFromDB);
            }
            connection.Close(); 
        }
        //This is the recursive bit, but doesn't re-enquire the database
        private void setMenuActiveByName(ToolStripItemCollection items, string name) 
        {
                foreach (ToolStripMenuItem item in items) 
                { 
                    if (item.Name == name) 
                    { 
                        item.Visible = true; 
                    } 
                    else 
                    {
                        setMenuActiveByName(item.DropDown.Items, name); 
                    } 
                }
        } 
