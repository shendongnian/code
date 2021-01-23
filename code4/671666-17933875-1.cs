    // in Aspx Page
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" 
                CommandArgument="1" /><asp:Label
               ID="Label1" runat="server" Text="Label"></asp:Label>
    //in Aspx.cs
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                ArrayList list = new ArrayList();
                list = BindDataToArray();
                int I = (Convert.ToInt32(Button1.CommandArgument.Count()));
                //int I = (Convert.ToInt32(Button1.CommandArgument));
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
                //con = new SqlConnection(con);
                SqlCommand cmd = new SqlCommand("SELECT SurveyName FROM tblSurveyName", con);
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
    
                foreach (DataRow dtrow in dt.Rows) { list.Add(dtrow["SurveyName"].ToString()); }
                return list;
            }
