             SqlDataReader myReader = null;
             SqlCommand myCommand = new SqlCommand("select drname from --- ",
                                                      myConnection);
             myReader = myCommand.ExecuteReader();
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
                 //adding list box to the panel
                 yourPanel.Controls.Add(new ListBox(){/*set id to the list here*/});
                 DR_list.Controls.Add(DrNames);
    
             }
         }
