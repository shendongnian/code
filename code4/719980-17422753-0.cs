    protected class ControlDescription
        {
            public string Name { get; set; }
            public bool isVisible { get; set; }
            public bool isEnabled { get; set; }
    
            public ControlDescription(string _name, int vis, int ena)
            {
                this.Name = _name;
                this.isVisible = (vis == 1);
                this.isEnabled = (ena == 1);
            }
        }
    
    protected void Page_Load(object sender, EventArgs e)
        {
            List<ControlDescription> CDescriptions = new List<ControlDescription>();
            //loop through data from database 
            //{
            //ControlDescription C = new ControlDescription(name,int,ena);
            //CDescriptions.Add(C);
            //}
                            
                    foreach (ControlDescription C in CDescriptions)
                    {
                        Control Ctrl = this.FindControl(C.Name);
                        if (Ctrl != null)
                        {
                            Ctrl.Visible = C.isVisible;
                            if (Ctrl is WebControl)
                                ((WebControl)Ctrl).Enabled = C.isEnabled;
                        }
                    }
        }
