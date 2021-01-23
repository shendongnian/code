    ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
    
            private void button1_Click(object sender, EventArgs e)
            {
                contextMenuStrip1.Items.Clear();
                contextMenuStrip1.Items.Add("item1");
                contextMenuStrip1.Items.Add("item2");
    
                contextMenuStrip1.Show(button1, new Point(0, button1.Height));
            }
    
            private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {
                if (e.ClickedItem.Text == "item1")
                {
                    MessageBox.Show(e.ClickedItem.Text);
                }
            }
