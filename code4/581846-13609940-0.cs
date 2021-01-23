        List<Control> lstControlSize = new List<Control>();
        public Form1()
        {
            InitializeComponent();
            SaveAllControls();
        }
        // save all controls to lstControlSize as default value
        public void SaveAllControls()
        {
            foreach (Control defaultControl in this.Controls)
            {
                if (defaultControl != null)
                {
                    this.lstControlSize.Add(defaultControl);
                }
            }
        }
           
        // reset all controls to default
        public void ResetSizeAllControls()
        {
            foreach (Control defaultControl in this.lstControlSize)
            {
                if (defaultControl != null)
                {
                    foreach (Control resizeControl in this.Controls)
                    {
                        if (resizeControl != null)
                        {
                            if (resizeControl.Name == defaultControl.Name)
                            {
                                resizeControl.Size = defaultControl.Size;
                                break;
                            }
                        }
                    }
                }
            }
        }
