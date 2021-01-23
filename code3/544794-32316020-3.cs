        private void xxxxx_KeyUp(object sender, KeyEventArgs e)
		{
			Keys pressed = e.KeyCode;
			if (e.Control) pressed = pressed | Keys.Control;
			if (e.Shift) pressed = pressed | Keys.Shift;
			if (e.Alt) pressed = pressed | Keys.Alt;
			ToolStripMenuItem actionItem = this.getContextMenuItems(this.cmsCellRightClick.Items)
				.Where(x => x.ShortcutKeys == pressed).FirstOrDefault();
			if (actionItem != null)
			{
				actionItem.PerformClick();
			}
			e.SuppressKeyPress = true;
		}
