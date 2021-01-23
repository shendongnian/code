        private void UpdateDatabase()
        {
            //Create an adapter to get the schema and point to the correct table
            //Can do something like SELECT * from table_name where 0 = 1
            SqlDataAdapter adapt = new SqlDataAdapter(yourSelectString, yourConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapt);
            
            try
            {
                adapt.Update(ds.Tables[0]);
                ds.Tables[0].AcceptChanges();
            }
            catch (Exception ex)
            {
                //Handle any exception here
            }
        }
