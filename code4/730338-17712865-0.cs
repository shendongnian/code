    public void RefeshListView()
   {
       this.listView1.BeginUpdate();
       MessageBox.Show("s");//this shows! only:\ !?!?!?
       listView1.Visible = false;
       listView1.Height = 222;
       listView1.EndUpdate();
       listView2.Clear();
       listView2.refresh();
