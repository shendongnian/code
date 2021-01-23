    public class DefaultPicture
    {
        private static string settings = "picture.settings";
        private System.Drawing.Bitmap image = new Bitmap(settings);
        public Bitmap Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
                this.image.Save(settings);
            }
        }
    }
