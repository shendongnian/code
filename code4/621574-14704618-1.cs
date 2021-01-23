    public ChartSettings chartOne{ get; set;}
    public Form1(bool archivePlotPreview)
    {
        InitializeComponent();
        chartOne = new ChartSettings(this.chart1, archivePlotPreview);
    }
