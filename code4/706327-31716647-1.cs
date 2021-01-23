        public partial class NonFlickerPanel : Panel
        {
           public NonFlickerPanel() : base()
           {
              this.SetStyle(ControlStyles.AllPaintingInWmPaint,
                                  ControlStyles.UserPaint 
                                  ControlStyles.OptimizedDoubleBuffer, 
                                  true);
           }
        } 
