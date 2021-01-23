      Color mColor;
      [XmlIgnore]
      public Color Color
      {
          get { return mColor; }
          set { mColor = value; }
      }
      
      [XmlElement("Color")]
      public string ColorStr
      {
          get { return ColorTranslator.ToHtml(Color); }
          set { Color = ColorTranslator.FromHtml(value); }
      }
