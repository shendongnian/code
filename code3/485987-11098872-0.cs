      private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
                {
                    // Move the dragged node when the left mouse button is used.
                    var node = e.Item as TreeNode;
        
                    if(node.Parent == null)
                        return;
        
                    var root = FindTraceRootNode(node);
                    var i = new string[] { root.Nodes[0].Nodes[0].Text, 
                        root.Nodes[1].Nodes[0].Text, 
                        root.Nodes[2].Nodes[0].Text, 
                        root.Nodes[3].Nodes[0].Text };
        
                    if (e.Button == MouseButtons.Left)
                    {
                        DoDragDrop(i, DragDropEffects.Move);
                    }
        
                    // Copy the dragged node when the right mouse button is used.
                    else if (e.Button == MouseButtons.Right)
                    {
                        DoDragDrop(i, DragDropEffects.Copy);
                    }
                }
        
                private TreeNode FindTraceRootNode(TreeNode node)
                {
                    while (node.Parent != treeView1.Nodes[0])
                    {
                        node = node.Parent;
                    }
                    return node;
                }
        
                // Set the target drop effect to the effect 
                // specified in the ItemDrag event handler.
                private void treeView1_DragEnter(object sender, DragEventArgs e)
                {
                    e.Effect = e.AllowedEffect;
                }
        
                // Select the node under the mouse pointer to indicate the 
                // expected drop location.
                private void TreeView1OnDragOver(object sender, DragEventArgs e)
                {
                    // Retrieve the client coordinates of the mouse position.
                    Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
        
                    // Select the node at the mouse position.
                    treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);
                }
        
        
                private void DataGridView1OnDragOver(object sender, DragEventArgs e)
                {
                    e.Effect = DragDropEffects.Move;
                }
        
                private void DataGridView1OnDragDrop(object sender, DragEventArgs e)
                {
                    Point dscreen = new Point(e.X, e.Y);
                    Point dclient = dataGridView1.PointToClient(dscreen);
                    DataGridView.HitTestInfo hitTest = dataGridView1.HitTest(dclient.X, dclient.Y);
        
                    if (hitTest.ColumnIndex == 0 && hitTest.Type == DataGridViewHitTestType.Cell)
                    {
                        e.Effect = DragDropEffects.Move;
                        //dataGridView1.Rows.Insert(hitTest.RowIndex, "hitTest", "hitTest", "hitTest", "hitTest");
                        var data = (object[]) e.Data.GetData(typeof(string[]));
                        dataGridView1.Rows.Insert(hitTest.RowIndex, data);
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
        
                }
