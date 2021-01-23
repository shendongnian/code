        public ThingWithGrid() {
            Grid.VisibleChanged += Grid_VisibleChanged;
        }
        private void Grid_VisibleChanged(object sender, EventArgs e)
        {
            UpdateSelectedRows(InitialSelection);
            Grid.VisibleChanged -= Grid_VisibleChanged;
        }
