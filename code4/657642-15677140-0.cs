	public static void BUTTON_CAL(object sender, System.Windows.Forms.KeyEventArgs e) {
		if(sender is Form) {
			var frm=sender as Form;
			if(e.KeyCode==Keys.A && e.Modifiers==Keys.Control) {
				if(frm.AddButton.Enabled)
					frm.AddButton.PerformClick();
				e.SuppressKeyPress=true;
			}
		}
	}
