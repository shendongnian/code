    class BitmapWrapper
    {
        private readonly int hash;
        public Bitmap Image { get; private set; }
        public BitmapWrapper(Bitmap img)
        {
            this.Image = img;
            this.hash = this.ComputeHash();
        }
    
        private int ComputeHash()
        {
            // you could turn this code into something unsafe to speed-up GetPixel
            // e.g. using lockbits etc...
            unchecked // Overflow is fine, just wrap
            {
                int h = 17;
                for (int x = 0; x < this.Image.Size.Width; x++)
                    for (int y = 0; y < this.Image.Size.Height; y++)
                        h = h * 23 + this.Image.GetPixel(x, y).GetHashCode();
                return h;
            }
        }
    
        public override int GetHashCode()
        {
            return this.hash;
        }
        public override bool Equals(object obj)
        {
            var objBitmap = obj as Bitmap;
            if (obj == null)
                return false;
            // use CompareMemCmp to hash collisions 
            return Utils.CompareMemCmp(this.Image, objBitmap); 
        }
    }
