    private void Form1_Load(object sender, EventArgs e)
    {
       listView1.Select();
       for (int i = 0; i < listView1.Items.Count; i++)
       {
           listView1.Items[i].Selected = true;
       }
    }
