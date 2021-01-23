        private override OnDoubleClick(...)    
        {
           ListViewHitTestInfo hit = this.HitTest(e.Location);
           if (hit.Item != null)
           {
              ListViewItem doubleClickedItem = hit.Item; 
           }
        }
