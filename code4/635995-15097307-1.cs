    public Form1()
        {
            InitializeComponent();
            magRadioBox.Checked = true;
            PropertyGrid propertyGrid1 = new PropertyGrid();
            propertyGrid1.CommandsVisibleIfAvailable = true;
            propertyGrid1.Text = "Graph and Plotting Options";
            propertyGrid1.SelectedObject = myChartInstance;
    
            this.Controls.Add(propertyGrid1);
        }
