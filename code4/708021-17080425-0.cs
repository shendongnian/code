    private void Form1_Load(object sender, System.EventArgs e)
     {
       listView1.LabelEdit = true;
      }
    private void listView1_DoubleClick(object sender, System.EventArgs e)
    {
      if(this.listView1.SelectedItems.Count==1)
         {
           this.listView1.SelectedItems[0].BeginEdit();
         }
     }
