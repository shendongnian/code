    private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) { return; }
            Point p = listView1.PointToClient(MousePosition);
            ListViewItem item = listView1.GetItemAt(p.X, p.Y);
            if (item == null) { return; }
            List<ListViewItem> collection = new List<ListViewItem>();
            foreach (ListViewItem i in listView1.SelectedItems)
            {
                collection.Add((ListViewItem)i.Clone());
            }
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Thread thMove = new Thread(unused => PasteFromMove(item.ToolTipText, collection));
                thMove.Start();
            }
            else
            {
                Thread thCopy = new Thread(unused => PasteFromCopy(item.ToolTipText, collection));
                thCopy.Start();
            }
            
        }
        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            if ((e.KeyState & 8) == 8)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.Move;
        }
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(e.Item,DragDropEffects.All);
        }
