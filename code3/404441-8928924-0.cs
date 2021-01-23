    public class newControl : Control {
      private ContentAlignment _TextAlign = ContentAlignment.TopLeft;
      public ContentAlignment TextAlign {
        get { return _TextAlign; }
        set { _TextAlign = value; }
      }
    }
