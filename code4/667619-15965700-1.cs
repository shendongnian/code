    protected void btn_Click(object sender, EventArgs e)
    {
            string mynameCheck = Label1.Text;
            if (mynameCheck=="Ronaldo")
            {
                Response.Write("Yes Name is Fine");
            }
            else
            {
                Response.Write("Name's not Fine");
    
            }
    }
