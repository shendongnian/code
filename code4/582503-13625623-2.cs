    bool rightClicked = false;
    int [] lviListIndex = null;
    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
          if (e.Button == System.Windows.Forms.MouseButtons.Right)
          {
                rightClicked = true;
                lviListIndex = new int[listView1.SelectedItems.Count];
                listView1.SelectedIndices.CopyTo(lviListIndex, 0);
          }
          else
          {
                rightClicked = false;
          }
    }
    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
          if (rightClicked)
          {
                listView1.SelectedIndices.Clear();   
          }
    }
        
    private void listView1_MouseUp(object sender, MouseEventArgs e)
    {
          if (rightClicked)
          {
                listView1.SelectedIndexChanged -= new System.EventHandler(listView1_SelectedIndexChanged);
                if (lviListIndex != null)
                {
                     foreach (int index in lviListIndex)
                     {
                          listView1.SelectedIndices.Add(index);
                     }
                }
                lviListIndex = null;
                listView1.SelectedIndexChanged += new System.EventHandler(listView1_SelectedIndexChanged);
          }
          rightClicked = false;
    }
