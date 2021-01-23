        using (var db = new PetaPoco.Database(string_connection, string_provider))
        {
            try
            {
                var ret = db.Query<MyTable>("select * from my_table_name").ToList();
                if(ret != null)
                {
                    dgv.DataSource = ret; 
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error: " + ex.Message); 
            }
        } // using
