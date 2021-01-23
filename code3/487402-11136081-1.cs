    for (int i = 0; i < 10; i++)
    {
       col1 = "Col1 value " + i;
       col2 = "Col2 value " + i;
       col3 = "Col3 value" + i;
    
       command1.Parameters.Clear();
    
       command1.Parameters.Add("@col1", SqlDbType.VarChar).Value = col1;
       command1.Parameters.Add("@col2", SqlDbType.VarChar).Value = col2;
       command1.Parameters.Add("@col3", SqlDbType.VarChar).Value = col3;
                    
       command1.ExecuteNonQuery();
    } 
