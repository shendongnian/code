    protected void check1_SelectedIndexChanged(object sender, EventArgs e) 
    {
     List<string> lst = new List<string>();
     for (int i = 0; i < check1.Items.Count; i++)
     {
        if (check1.Items[i].Selected)
        {           
           lst.Add(check1.Items[i]);            
         }           
      }
      lst.Sort();
      foreach(list l in lst)
      {
         comment.Text += l;
      }
     }
