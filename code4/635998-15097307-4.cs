            private void propertyGrid1_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
            {
               MyChart myChartInstance = ((MyChart)((PropertyGrid)sender).SelectedObject);
               myChartInstance.Invalidate(); // or Redraw() etc.
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
