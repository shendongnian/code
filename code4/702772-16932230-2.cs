    public class bildelisteDyr
    {
        static Bitmap[] bildeListeInternal;
        static bildelisteDyr() {
            bildeListeInternal = new Bitmap[21];
            bildeListeInternal[0] = Properties.Resources.ål;
            //...
            bildeListeInternal[20] = Properties.Resources.turtle;
        }
    
        public static Bitmap bildeListe (int index) {
            return bildeListeInternal[index];
        }
    }
