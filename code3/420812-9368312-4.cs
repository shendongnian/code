    public class MyUserControl : UserControl
    {
        public new double Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                 if(!(value > 100 && value < 200))
                     base.Width = value;
            }
        }
    }
