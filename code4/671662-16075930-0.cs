    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" CommandArgument="0" />//dEFINATION OF BUTTON ON ASPX PAGE
    
    
       
    
  
       protected void Button1_Click(object sender, EventArgs e)
            {
                ArrayList list = new ArrayList();
              list=BindDataToArray();
                int I=( Convert.ToInt32(Button1.CommandArgument));
                if (I < list.Count)
                {
                   
                  Label1.Text = list[I] as string; //Label in which u want to show message
                    Button1.CommandArgument = (I + 1).ToString();
                }
                else
                {
                    Label1.Text = "eND OF LIST";
                    Button1.Enabled = false;
                }
            }
