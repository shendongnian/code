            private void propertyGrid1_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
            {
               // Redraw the chart.
               chart1.Invalidate();
            }
            public Form1()
            {
                InitializeComponent();
                magRadioBox.Checked = true;
                PropertyGrid propertyGrid1 = new PropertyGrid();
                propertyGrid1.CommandsVisibleIfAvailable = true;
                propertyGrid1.Text = "Graph and Plotting Options";
                
                // Create your chart.
                chart1 = new MyChart();
                // Attach your chart to Property Grid.
                propertyGrid1.SelectedObject = (MyChart) chart1;
                propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
        
                this.Controls.Add(propertyGrid1);
            }
