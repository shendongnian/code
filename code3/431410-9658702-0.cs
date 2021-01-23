	class MyTabPage : TabPage {
		event EventHandler Activated;
		public void OnActivated() {
			if (Activated != null)
			   Activated(this, EventArgs.Empty);
		}
	}
	void HandleTabIndexChanged(object sender, EventArgs args) {
		var tabControl = sender as TabControl;
		var tabPage = tabControl.SelectedTab as MyTabPage;
		if (tabPage != null)
			tabPage.OnActivated();
	}
