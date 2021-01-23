     protected void fillEntrylevelList()
    {
        using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["TestEnvironment"].ConnectionString))
        {
            string EntrylevelQuery = @"INSERT SQL STATEMENT HERE";
            OleDbCommand command = new OleDbCommand(EntrylevelQuery, connection);
            if (Session["SavedLevelItems"] != null)
                {
                    CheckBoxListLevel.Items.Clear();
                    List<ListItem> SessionList = (List<ListItem>)Session["SavedLevelItems"];
                    foreach (var item in SessionList)
                    {
                        try
                        {
                            CheckBoxListLevel.Items.Add(item);
                        }
                        catch { }
                    }
                }
            else
            {
                connection.Open();
                CheckBoxListLevel.DataTextField = "bez_level";
                CheckBoxListLevel.DataValueField = "id_level";
                OleDbDataReader ListReader = command.ExecuteReader();
                CheckBoxListLevel.DataSource = ListReader;
                CheckBoxListLevel.DataBind();
                ListReader.Close(); ListReader.Dispose();
                GC.Collect();
            }
        }
    }
