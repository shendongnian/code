    public class Box
    {
        public Label LabelDown = new Label();
        public byte SavedID;
    
        public Box(EventHandler InsideEvent)
        {
    
            LabelDown.Text = null;
            LabelDown.Size = new Size(96, 32);
            LabelDown.Visible = true;
            LabelDown.Click += OnLabelClick;
    
            SavedID = 0;
    
            _insideEvent = InsideEvent;
        }
    
        private EventHandler _insideEvent;
    
        private OnLabelClick(object sender, EventArgs e)
        {
            if (_insideEvent != null)
                _insideEvent(this, e);
        }
    }
    void Box_goInside_Click(object sender, EventArgs e)
    {
        Box box = (Box)sender;
        
        // Do your stuff
    }
