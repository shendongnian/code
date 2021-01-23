    static Dictionary <int, int> list = new Dictionary <int, int>();
    
    static YourClassName
    {
      for(int i=0 ; i < 100 ; i++)
      {
         list.add(i,0);
      }
    }
    
    protected void SelectedIndexChanged (object sender, EventArgs e)
    { 
      list.[gridview1.GridView1.SelectedRow.DataItemIndex]++;
    }
