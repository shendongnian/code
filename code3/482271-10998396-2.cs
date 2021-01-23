    private void button1_Click(object sender, EventArgs e)
            {
                var child = new Form2();
                child.FormClosing += new FormClosingEventHandler(ChildFormClosing);
                this.Enabled = false;
                child.Show(this.MdiParent);
            }
    
            void ChildFormClosing(object sender, FormClosingEventArgs e)
            {
                var child = sender as Form2;
                if (child != null)
                {
                    if (child.DialogResult == DialogResult.None)
                    {
                        // do data grid view manipulation here 
                    }
                }
                Enabled = true;
            }
