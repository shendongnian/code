       private void Populate()
        {
            int position;
            int i = 0;
             
            //here children in list of string type
            foreach (string child in children)
            {
                this.productLineTabs.TabPages.Add(child);
                AxSftTree treeadd = loadtree(this.productLineTabs.TabPages[i]);
                this.tree.Add(treeadd);
           
                this.tree[i].Columns = 2;
                this.tree[i].set_ColumnText(0, "Col1");
                this.tree[i].set_ColumnText(1, "Col2");
                position = this.tree[i].AddItem(child);
                i++;
            }
            form plv = new form();
            plv.Controls.Add(this);
            plv.Show();
        }
        private AxSftTree loadtree(TabPage tab)
        {
            AxSftTree treeobject = new AxSftTree();
            ((System.ComponentModel.ISupportInitialize)(treeobject)).BeginInit();
            SuspendLayout();
            tab.Controls.Add(treeobject);
            treeobject.Dock = DockStyle.Fill;
            ResumeLayout();
            ((System.ComponentModel.ISupportInitialize)(treeobject)).EndInit();
            return treeobject;
        }
