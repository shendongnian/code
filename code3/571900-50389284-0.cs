        public static void KeepOpenOnDropdownCheck (this ToolStripMenuItem ctl)
        {
            foreach (var item in ctl.DropDownItems.OfType<ToolStripMenuItem>())
            {
                item.MouseEnter += (o, e) => ctl.DropDown.AutoClose = false;
                item.MouseLeave += (o, e) => ctl.DropDown.AutoClose = true;
            }
        }
