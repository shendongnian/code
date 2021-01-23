	dgv.EditingControlShowing += (s, e) =>
		{
			DataGridViewComboBoxEditingControl editingControl = e.Control as DataGridViewComboBoxEditingControl;
			if (editingControl != null)
				editingControl.MouseWheel += (s2, e2) =>
					{
						if (!editingControl.DroppedDown)
						{
							((HandledMouseEventArgs)e2).Handled = true;
							dgv.Focus();
						}
					};
		};
