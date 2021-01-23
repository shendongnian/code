            private void propertyGrid1_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
            {
               // Get the myChartInstance from the property grid.
               MyChart myChart = (MyChart)(((PropertyGrid)sender).SelectedObject);
               // Call the method that will refresh the myChartInstace.
               myChart.Invalidate(); // ...Redraw() etc.
            }
            public Form1()
            {
                InitializeComponent();
                magRadioBox.Checked = true;
                PropertyGrid propertyGrid1 = new PropertyGrid();
                propertyGrid1.CommandsVisibleIfAvailable = true;
                propertyGrid1.Text = "Graph and Plotting Options";
                propertyGrid1.SelectedObject = myChartInstance;
                propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
        
                this.Controls.Add(propertyGrid1);
            }
