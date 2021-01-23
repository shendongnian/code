        private void MoveItems(ListView sender, MoveDirection direction)
        {
            bool valid = sender.SelectedItems.Count > 0 &&
                        ((direction == MoveDirection.Down && (sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1))
                        || (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));
            if (valid)
            {                
                bool start = true;
                int first_idx = 0;                
                List<ListViewItem> items = new List<ListViewItem>();
                // ambil data
                foreach (ListViewItem i in sender.SelectedItems)
                {
                    if (start)
                    {
                        first_idx = i.Index;
                        start = false;
                    }
                    items.Add(i);
                }
                sender.BeginUpdate();
                // hapus
                foreach (ListViewItem i in sender.SelectedItems) i.Remove();
                // insert
                if (direction == MoveDirection.Up)
                {
                    int insert_to = first_idx - 1;
                    foreach (ListViewItem i in items)
                    {
                        sender.Items.Insert(insert_to, i);
                        insert_to++;
                    }                    
                }
                else
                {
                    int insert_to = first_idx + 1;
                    foreach (ListViewItem i in items)
                    {
                        sender.Items.Insert(insert_to, i);
                        insert_to++;
                    }   
                }                
                sender.EndUpdate();
            }            
        }
