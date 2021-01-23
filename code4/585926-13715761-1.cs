    namespace PDF_Library.VisualWebPart1
    {
        public partial class PDF_Library : Usercontrol   
        {
            public static PDF_Library Current;
            public PDF_Library() : base() {
               Current = this;
            }
    
        }
    }
