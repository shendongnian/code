    class preferencesGUI
    {
        // ... Some code ...
        public event Action RequestGUIUpdate;
        protected void OnRequestGUIUpdate() { if (this.RequestGUIUpdate == null) return; RequestGUIUpdate(); }
    
        // ... Some more code ...
    
        private void applychanges_Click(object sender, EventArgs e)
        {
            OnRequestGUIUpdate();
        }
    
        // ... Some more code ...
    }
