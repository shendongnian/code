    // Declare the ContextMenuStrip control.
        private ContextMenuStrip fruitContextMenuStrip;
    
        public Form3()
        {
            // Create a new ContextMenuStrip control.
            fruitContextMenuStrip = new ContextMenuStrip();
    
            // Attach an event handler for the 
            // ContextMenuStrip control's Opening event.
            fruitContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(cms_Opening);
    
            // Create a new ToolStrip control.
            ToolStrip ts = new ToolStrip();
    
            // Create a ToolStripDropDownButton control and add it
            // to the ToolStrip control's Items collections.
            ToolStripDropDownButton fruitToolStripDropDownButton = new ToolStripDropDownButton("Fruit", null, null, "Fruit");
            ts.Items.Add(fruitToolStripDropDownButton);
    
            // Dock the ToolStrip control to the top of the form.
            ts.Dock = DockStyle.Top;
    
            // Assign the ContextMenuStrip control as the 
            // ToolStripDropDownButton control's DropDown menu.
            fruitToolStripDropDownButton.DropDown = fruitContextMenuStrip;
    
            // Create a new MenuStrip control and add a ToolStripMenuItem.
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem fruitToolStripMenuItem = new ToolStripMenuItem("Fruit", null, null, "Fruit");
            ms.Items.Add(fruitToolStripMenuItem);
    
            // Dock the MenuStrip control to the top of the form.
            ms.Dock = DockStyle.Top;
    
            // Assign the MenuStrip control as the 
            // ToolStripMenuItem's DropDown menu.
            fruitToolStripMenuItem.DropDown = fruitContextMenuStrip;
    
            // Assign the ContextMenuStrip to the form's 
            // ContextMenuStrip property.
            this.ContextMenuStrip = fruitContextMenuStrip;
    
            // Add the ToolStrip control to the Controls collection.
            this.Controls.Add(ts);
    
            //Add a button to the form and assign its ContextMenuStrip.
            Button b = new Button();
            b.Location = new System.Drawing.Point(60, 60);
            this.Controls.Add(b);
            b.ContextMenuStrip = fruitContextMenuStrip;
    
            // Add the MenuStrip control last.
            // This is important for correct placement in the z-order.
            this.Controls.Add(ms);
        }
