    using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
    {
        myDatabaseConnection.Open();
        using (SqlCommand SqlCommand = new SqlCommand("Select ID, LastName from Employee", myDatabaseConnection))
        {
            SqlDataReader dr = SqlCommand.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(string.Format("{0}\n{1}",dr["LastName"],dr["ID"]));
            }
        }
    }
    //DrawItem
    //first, set listBox1.DrawMode = DrawMode.OwnerDrawFixed;
    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {            
            e.DrawBackground();
            string[] ss = listBox1.Items[e.Index].ToString().Split(new char[]{'\n'});
            Rectangle rect = new Rectangle(e.Bounds.Left, e.Bounds.Top, (int) (e.Bounds.Width * 0.5), e.Bounds.Height);
            Rectangle rect2 = new Rectangle((int)(e.Bounds.Width * 0.5), e.Bounds.Top, e.Bounds.Width - (int)(e.Bounds.Width * 0.5), e.Bounds.Height);
            StringFormat sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(ss[0], listBox1.Font, new SolidBrush(listBox1.ForeColor), rect,sf);
            e.Graphics.DrawString(ss[1], listBox1.Font, new SolidBrush(listBox1.ForeColor), rect2, sf);
        } 
