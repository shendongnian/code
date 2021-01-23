    public struct myControl
    {
        public string name;
        public Size size;
    }
    List<myControl> lstControlSize = new List<myControl>();
    myControl defControl = new myControl();
    public Form1()
    {
        InitializeComponent();
        SaveAllControls();
    }
    public void SaveAllControls()
    {
        foreach (Control defaultControl in this.Controls)
        {
            if (defaultControl != null)
            {
                defControl.name = defaultControl.Name;
                defControl.size = defaultControl.Size;
                this.lstControlSize.Add(defControl);
            }
        }
    }
    public void ResetSizeAllControls()
    {
        foreach (myControl defaultControl in this.lstControlSize)
        {
            foreach (Control resizeControl in this.Controls)
            {
                if (resizeControl != null)
                {
                    if (resizeControl.Name == defaultControl.name)
                    {
                        resizeControl.Size = defaultControl.size;
                        break;
                    }
                }
            }
        }
    }
