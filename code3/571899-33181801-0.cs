     private void removeMultipleItemsToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            removeMultipleItemsToolStripMenuItem.DropDownItems.Clear();  
            ToolStripMenuItem detailMenuItem;
            TreeNode vendorSectionNode = treePromotions.SelectedNode;
            for (int vsn = 0; vsn < vendorSectionNode.Nodes.Count; vsn++)
            {
                //add checkbox item
                detailMenuItem = new ToolStripMenuItem(vendorSectionNode.Nodes[vsn].Text);
                detailMenuItem.Tag = vendorSectionNode.Nodes[vsn].Tag;
                detailMenuItem.CheckOnClick = true;
                removeMultipleItemsToolStripMenuItem.DropDownItems.Add(detailMenuItem);
            }
            //add action buttons
            Button buttonDeleteMultiple = new Button();
            buttonDeleteMultiple.Text = "Remove Checked Items";
            ToolStripControlHost buttonHost = new ToolStripControlHost(buttonDeleteMultiple);
            buttonDeleteMultiple.Click += new EventHandler(buttonDeleteMultiple_Click);
            removeMultipleItemsToolStripMenuItem.DropDownItems.Add(buttonHost);
            Button buttonCancelMultipleDelete = new Button();
            buttonCancelMultipleDelete.Text = "CANCEL";
            buttonHost = new ToolStripControlHost(buttonCancelMultipleDelete);
            buttonCancelMultipleDelete.Click += new EventHandler(buttonCancelMultipleDelete_Click);
            removeMultipleItemsToolStripMenuItem.DropDownItems.Add(buttonHost);
            removeMultipleItemsToolStripMenuItem.DropDown.AutoClose = false;
            menuVendorSection.AutoClose = false;
        }
        private void buttonDeleteMultiple_Click(object sender, EventArgs e)
        {
            
            //delete items
            for (int dmi = 0; dmi < removeAllItemsToolStripMenuItem.DropDownItems.Count - 2; dmi++) //do not include buttons
            {
                ((Detail)removeAllItemsToolStripMenuItem.DropDownItems[dmi].Tag).Delete(); //deletes item from database
            }
            //rebuild leaf
            treePromotions.SelectedNode.Nodes.Clear();
            addItemNodes(treePromotions.SelectedNode);  //builds leaf nodes from database
            //close menus
            removeMultipleItemsToolStripMenuItem.DropDown.Close();
            menuVendorSection.AutoClose = true;
            menuVendorSection.Close();
        }
        private void buttonCancelMultipleDelete_Click(object sender, EventArgs e)
        {
            //just close menus
            removeMultipleItemsToolStripMenuItem.DropDown.Close();
            menuVendorSection.AutoClose = true;
            menuVendorSection.Close();
        }
