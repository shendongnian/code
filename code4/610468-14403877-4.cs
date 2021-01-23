    public class Rectangle
    {
        public virtual Int32 Height { get; set; }
        public virtual Int32 Width { get; set; }
    }
 
    public class Square : Rectangle
    {
        public override Int32 Height
        {
            get { return base.Height; }
            set { SetDimensions(value); }
        }
 
        public override Int32 Width
        {
            get { return base.Width; }
            set { SetDimensions(value); }
        }
 
        private void SetDimensions(Int32 value)
        {
            base.Height = value;
            base.Width = value;
        }
    }
