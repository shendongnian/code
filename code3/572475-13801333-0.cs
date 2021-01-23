    [Serializable]
    public struct XmlRectangle
    {
	    #endregion Public Properties
	   
        public int X {get; set; }
        public int Y {get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        #endregion Public Properties
        #region Implicit Conversion Operators
        public static implicit operator Rectangle(XmlRectangle xmlRectangle)
        {
            return new Rectangle(xmlRectangle.X, xmlRectangle.Y, xmlRectangle.Width, xmlRectangle.Height);
        }
		
        public static implicit operator XmlRectangle(Rectangle rectangle)
        {
            return result = new XmlRectangle(){ X = rectangle.X, Y = Rectangle.Y, Height = Rectangle.Height, width  = Rectangle.Width };
        }
        #endregion Implicit Conversion Operators
    }
