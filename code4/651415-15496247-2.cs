     DataTable dt = new DataTable();
    foreach (string word in words)
                {
                    SqlCommand cmd= new SqlCommand("select * from skills  where (skills  like '%"+word+"%')",con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd); 
                    DataTable dt1 = new DataTable();
                    da.Fill(dt1);
                    if (dt!= null)// to check if datatable is empty:-
                    dt.Merge(dt1, false, MissingSchemaAction.Add);
                    else
                    dt=dt1.copy();// copy one datatable to another
                    dt1.clear();
                }
