        private ToolStripMenuItem MakeWindowMenu()
        {
            var tsi = new ToolStripMenuItem("Window");
            tsi.DropDownItems.Add(CreateMenuItem("Cascade", "Cascade the features", () => Master.MDIForm.LayoutMdi(MdiLayout.Cascade)));
            tsi.DropDownItems.Add(CreateMenuItem("Tile Vertical", "Tile the features vertically", () => {  }));
            return tsi;
        }
        private ToolStripMenuItem CreateMenuItem(string Caption, string tooltip, Action onClickEventHandler)
        {
            var item = new ToolStripMenuItem(Caption);
            item.Click += (s, e) => { onClickEventHandler.Invoke(); };
            item.ToolTipText = tooltip;
            return item;
        }
