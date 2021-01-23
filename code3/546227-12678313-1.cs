    <asp:TextBox ID="System.ID_Value(FromDB)"  value="Month_Value_(value from DB)" runat="server"></asp:TextBox>
    
    then on the click event of the save button 
    
     protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (var row in Table1.Rows)
            {
                string[] allkeys = Request.Form.AllKeys;
                foreach (string key in allkeys)
                {
                    if (key.ToUpper().StartsWith("System_ID"))
                    {
                        var ID = Convert.ToInt32(key.Split('_')[1]);           
                    }
                    if (key.ToUpper().StartsWith("MOnth_Value"))
                    {
                        var Jan = Convert.ToInt32(key.Split('_')[2]);
                        var feb = Convert.ToInt32(key.Split('_')[3]);
                    }
                    // and so on then you call the update method
                }  
            }
        }
