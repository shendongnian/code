        private static bool EnableMenuItem(ToolStripItemCollection items, string name) {
            foreach (ToolStripMenuItem item in items) {
                if (item.Name == name) {
                    item.Visible = true;
                    return true;
                }
                else if (item.DropDown.Items.Count > 0 {
                    if (EnableMenuItem(item.DropDown.Items, name)) return true;
                }
            }
            return false;
        }
