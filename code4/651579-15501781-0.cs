    while (myReader.Read())
             {
                 //Response.Write(myReader["DrName"].ToString());
                 int tRows;  
                   int tCells;
                 List<string> DrNames = new List<string>();
    
                 for (tCells = 0; tCells < 4; tCells++)
                  {
                      string a = myReader["DrName"].ToString();
                      Response.Write(a);
                        DrNames.Add(a);
    
                  }
    
             }
    DR_list.DataSouce = DrNames;
    DR_list.DataBind();
