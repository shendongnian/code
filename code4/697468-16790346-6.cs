    TimePicker picker1;
    public Form1()
    {
        InitializeComponent();
        picker1 = new TimePicker();
        picker1.Name = "timePicker";
        picker1.Location = new Point(10, 10);
        Controls.Add(picker1);
    }
