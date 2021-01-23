    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click"  
                CommandArgument="0" />//dEFINATION OF BUTTON ON ASPX PAGE
    
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
    public ArrayList BindDataToArray()
    {
        ArrayList list = new ArrayList();
        DataTable dt = new DataTable();
        con = new SqlConnection(str);
        cmd = new SqlCommand("select Question from  Questions", con);
        con.Open();
        adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
    
        foreach (DataRow dtrow in dt.Rows)
        {
            list.Add(dtrow["Question"].ToString());
        }
        return list;
    }
