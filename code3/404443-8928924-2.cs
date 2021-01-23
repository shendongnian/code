    using System.ComponentModel;
    using System.Windows.Forms;
    public class newControl : Control {
      private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
      [Description("The alignment of the text that will be displayed on the control.")]
      [DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
      public ContentAlignment TextAlign {
        get { return _TextAlign; }
        set { _TextAlign = value; }
      }
    }
