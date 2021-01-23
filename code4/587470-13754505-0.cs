        public EOMForm()
        {
            InitializeComponent();
            // Show the connection string when hovering over the database label (Test Mode Only)
            if(Properties.Settings.Default.TestMode)
                this.toolTip1.SetToolTip(this.databaseLabel, EomAppCommon.EomAppSettings.ConnStr);
            // Security
            DisableMenus();
        }
        private void DisableMenus()
        {
            // Disable individual menu items
            foreach (var menuItem in this.TaggedToolStripMenuItems())
                menuItem.Enabled = Security.User.Current.CanDoMenuItem((string)menuItem.Tag);
            // Apply disabled color to top level menus that have all their items disabled
            foreach (var menu in menuStrip1.DisabledMenus())
                menu.ForeColor = SystemColors.GrayText;
        }
