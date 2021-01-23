     private void Form1_Load(object sender, EventArgs e)
            {
                listView1.Columns.Add("Image Name");
                listView1.Columns.Add("Username");
                listView1.Columns.Add("CPU");
                listView1.Columns.Add("Memory");
    
                listView1.View = View.Details;
     
            }
