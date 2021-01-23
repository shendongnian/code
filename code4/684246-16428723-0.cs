    public class MyControl : Control
    {
        private Font myOtherFont;
        public Font MyOtherFont
        {
            get
            {
                if (this.myOtherFont == null)
                {
                    if (base.Parent != null)
                        return base.Parent.Font;
                }
                return this.myOtherFont;
            }
            set
            {
                this.myOtherFont = value;
            }
        }
        private bool ShouldSerializeMyOtherFont()
        {
            if (base.Parent != null)
                if (base.Parent.Font.Equals(this.MyOtherFont))
                    return false;
            if (this.MyOtherFont == null)
                return false;
            return true;
        }
        private void ResetMyOtherFont()
        {
            if (base.Parent != null)
                this.MyOtherFont = base.Parent.Font;
            else
                this.MyOtherFont = Control.DefaultFont;
        }
    }
