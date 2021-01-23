    public class Obj
    {
        private Bitmap myImage;
        [Category("Main Category")]
        [Description("Your favorite image")]
        [Editor(typeof(BitmapLocationEditor), typeof(UITypeEditor))]
        public Bitmap MyImage
        {
            get { return myImage; }
            set
            {
                myImage = value;
            }
        }
    }
