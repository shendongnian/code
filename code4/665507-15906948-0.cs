     //in master page pseudo code
     public void UpdateRecord(string updateField)
     {
           using (myConnection = new connection())
           {
                //master page does something with db
                try
                {
                      ContentPage.GetContent(myConnection);
                }
                catch
                {
                     // handle expected errors
                     // fail on other ones
                }
           }
     }
