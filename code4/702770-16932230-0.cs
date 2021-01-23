    public class bildelisteDyr
    {
        Bitmap[] bildeListe;
        public bildelistDyr() {
            bildeListe = new Bitmap[21];
            bildeListe[0] = Properties.Resources.ål;
            //...
            bildeListe[20] = Properties.Resources.turtle;
        }
    
        public static Bitmap bildeListe (int index) {
            return bildeListe[index];
        }
    }
