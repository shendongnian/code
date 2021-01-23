        private void PopulateComboBox(ComboBox comboBox)
        {
            var items = new[]
                {
                    new ConnectionListItem {DisplayName = "Site 1", ConnectionString = new SqlConnectionStringBuilder("Server=...")},
                    new ConnectionListItem {DisplayName = "Site 2", ConnectionString = new SqlConnectionStringBuilder("Server=...")},
                };
            comboBox.Items.AddRange(items);
        }
        class ConnectionListItem
        {
            public string DisplayName { get; set; }
            public SqlConnectionStringBuilder ConnectionString { get; set; }
            public override string ToString()
            {
                return DisplayName;
            }
        }
