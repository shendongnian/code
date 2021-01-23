                 int Count = 0;
                using (SqlConnection conn = new SqlConnection ( " Your ConnectionString" ))
                {
    
                    using (SqlCommand cmd1 = new SqlCommand ( "Exists", conn ))
                    {
    
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add ( new SqlParameter ( "@Url", URL ) );
    
                        conn.Open ();
    
                        if( Convert.ToInt32 ( cmd1.ExecuteScalar () ) > 0 )
                        {
                            Count +=1;
                        }
                        conn.Dispose ();
                        
                    }
                }
