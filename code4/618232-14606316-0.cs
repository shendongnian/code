    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["con"]))
    {
        var adaptor = new SqlDataAdapter();
        adaptor.SelectCommand = new SqlCommand("SELECT * FROM [Record]", con);
    
        var cbr = new SqlCommandBuilder(adaptor);
    
        cbr.GetDeleteCommand();
        cbr.GetInsertCommand();
        cbr.GetUpdateCommand();
    
        try
                    {
                        con.Open();
                       
                        adaptor.Update(dtable);
                        MessageBox.Show("Changes Saved","Information");
                    }
                    catch (SqlDbException ex)
                    {
                        MessageBox.Show(ex.Message, "SqlException Error");
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message, "Exception Error");
                    }
    
        }
}
