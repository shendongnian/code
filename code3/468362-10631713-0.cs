        private void buttonAddFav_Click(object sender, EventArgs e)
        {
            ToolStripItem item = new ToolStripMenuItem();
            //Name that will apear on the menu
            item.Text = "Jhon Smith";
            //Put in the Name property whatever neccessery to retrive your data on click event
            item.Name = "GridViewRowID or DataKeyID";
            //On-Click event
            item.Click += new EventHandler(item_Click);
            //Add the submenu to the parent menu
            favToolStripMenuItem.DropDownItems.Add(item);
        }
        void item_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
