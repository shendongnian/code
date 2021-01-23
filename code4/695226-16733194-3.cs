    public class CustomButton : Button
    {
        private MyPointF _locationF = new MyPointF() { X = 50, Y = 50 };
        [Category("Layout")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public MyPointF LocationF
        {
            get
            {
                return _locationF;
            }
            set
            {
                _locationF = value;
            }
        }
    }
