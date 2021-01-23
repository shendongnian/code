        dataGridView1.MouseDown += new MouseEventHandler(this.dataGridView_MouseDown);
        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var ht = dataGridView1.HitTest(e.X, e.Y);
                if (ht.ColumnIndex == 4)
                {
                    //Create the ContextStripMenu for Creating the PO Sub Form
                    ContextMenuStrip Menu = new ContextMenuStrip();
                    ToolStripMenuItem MenuOpenPO = new ToolStripMenuItem("Open PO");
                    MenuOpenPO.MouseDown += new MouseEventHandler(MenuOpenPO_Click);
                    Menu.Items.AddRange(new ToolStripItem[] { MenuOpenPO });
                    //Assign created context menu strip to the DataGridView
                    dataGridView1.ContextMenuStrip = Menu;
                }
                else
                    dataGridView1.ContextMenuStrip = null;
            }
        }
