        private ToolStripMenuItem MakeWindowMenu()
        {
            var tsi = new ToolStripMenuItem("Window");
            tsi.DropDownItems.Add(CreateMenuItem("Cascade", "Cascade the features", () => DoWindowLayout(MdiLayout.Cascade)));
            tsi.DropDownItems.Add(CreateMenuItem("Tile Vertical", "Tile the features vertically", () => this.DoWindowTileVertically));
            //etc
            return tsi;
        }
        private ToolStripMenuItem CreateMenuItem(string Caption, string tooltip, Action onClickEventHandler)
        {
            var item = new ToolStripMenuItem(Caption);
            item.Click += (s,e) => onClickEventHandler.Invoke();
            item.ToolTipText = tooltip;
            return item;
        }
        public DoWindow DoWindowLayout(MdiLayout layoutInstruction)
        {
            Master.MDIForm.LayoutMdi(layoutInstruction);
        }
