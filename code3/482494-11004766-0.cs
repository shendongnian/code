    public MyForm(Type typeToDisplay)
            {
                InitializeComponent();
    
                PropertyInfo[] settableProperties = typeToDisplay.GetProperties(BindingFlags.Instance | BindingFlags.Public);
    
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.ColumnCount = 2;
                panel.RowCount = settableProperties.Length+1;
                panel.Name = "LayoutPanel";
                this.Controls.Add(panel);
    
                int rowIndex = 0;
    
                foreach (PropertyInfo info in settableProperties)
                {
                    Label propLabel = new Label();
                    propLabel.Text = info.Name;
    
                    TextBox propField = new TextBox();
    
                    panel.Controls.Add(propLabel, 0, rowIndex);
                    panel.Controls.Add(propField, 1, rowIndex);
    
                    rowIndex++;
                }
    
                panel.Controls.Add(new Button() { Text = "OK", Name="OK" }, 0, rowIndex);
                panel.Controls.Add(new Button() { Text = "Cancel", Name="Cancel" }, 1, rowIndex);
    
                panel.Controls["Cancel"].Click += new EventHandler(CloseForm);
                panel.Controls["OK"].Click += new EventHandler(SaveChanges);
    
                panel.Height = this.Height;
                panel.Width = this.Width;
    
            }
    
            private void CloseForm(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void SaveChanges(object sender, EventArgs e)
            {
                MessageBox.Show("Save changes was clicked!");
                this.Close();
            }
