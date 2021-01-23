        public Form1()
        {
            var grid = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = false };
            var column = new DataGridViewComboBoxColumn();
            column.DataPropertyName = "Selected";
            column.DisplayMember = "Text";
            column.ValueMember = "Value";
            grid.Columns.Add(column);
            grid.DataSource = new[]
            {
                new Item
                {
                    Selected = 1 ,
                    Elements = new[]
                    {
                        new Element { Text = "first", Value = 1 },
                        new Element { Text = "third", Value = 3 }
                    }
                },
                new Item
                {
                    Selected = 5 ,
                    Elements = new[]
                    {
                        new Element { Text = "second", Value = 2 },
                        new Element { Text = "fifth", Value = 5 },
                        new Element { Text = "sixth", Value = 6 }
                    }
                }
            };
            Controls.Add(grid);
            grid.RowsAdded += new DataGridViewRowsAddedEventHandler(grid_RowsAdded);
        }
        private void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var grid = (DataGridView)sender;
            for (int i = 0; i < e.RowCount; i++)
            {
                var item = (Item)grid.Rows[e.RowIndex + i].DataBoundItem;
                var cell = (DataGridViewComboBoxCell)grid.Rows[e.RowIndex + i].Cells[0];
                cell.DataSource = item.Elements;
                Debug.WriteLine(cell.Items.Count);
            }
        }
    }
    internal class Item
    {
        public int Selected { get; set; }
        public IEnumerable<Element> Elements { get; set; }
    }
    internal class Element
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
