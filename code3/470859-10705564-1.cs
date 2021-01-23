        private override OnDoubleClick(object sender, MouseEventArgs e)    
        {
           ListViewHitTestInfo hit = listView1.HitTest(e.Location);
           if (hit.Item != null)
           {
              ListViewItem doubleClickedItem = hit.Item; 
           }
        }
