    public class RichBox : RichTextBox {
      private const UInt32 CFM_BOLD = 0x00000001;
      private const UInt32 CFM_ITALIC = 0x00000002;
      private const UInt32 CFM_UNDERLINE = 0x00000004;
      private const UInt32 CFM_STRIKE = 0x00000008;
      private const UInt32 CFM_FACE = 0x20000000;
      private const UInt32 CFM_SIZE = 0x80000000;
      private const int WM_PAINT = 0xF;
      private const int WM_SETREDRAW = 0xB;
      private const int WM_USER = 0x400;
      private const int EM_SETCHARFORMAT = (WM_USER + 68);
      private const int SCF_SELECTION = 0x0001;
      private const int EM_GETEVENTMASK = WM_USER + 59;
      private const int EM_SETEVENTMASK = WM_USER + 69;
      private const int EM_GETSCROLLPOS = WM_USER + 221;
      private const int EM_SETSCROLLPOS = WM_USER + 222;
      [StructLayout(LayoutKind.Sequential)]
      private struct CHARFORMAT {
        public int cbSize;
        public uint dwMask;
        public uint dwEffects;
        public int yHeight;
        public int yOffset;
        public int crTextColor;
        public byte bCharSet;
        public byte bPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] szFaceName;
        public short wWeight;
        public short sSpacing;
        public int crBackColor;
        public int LCID;
        public uint dwReserved;
        public short sStyle;
        public short wKerning;
        public byte bUnderlineType;
        public byte bAnimation;
        public byte bRevAuthor;
      }
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      private static extern IntPtr LoadLibrary(string lpFileName);
      [DllImport("user32", CharSet = CharSet.Auto)]
      private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref CHARFORMAT lParam);
      [DllImport("user32.dll")]
      private static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, ref Point lParam);
      [DllImport("user32.dll")]
      private static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, IntPtr lParam);
      private bool frozen = false;
      private Point lastScroll = Point.Empty;
      private IntPtr lastEvent = IntPtr.Zero;
      private int lastIndex = 0;
      private int lastWidth = 0;
      protected override CreateParams CreateParams {
        get {
          var cp = base.CreateParams;
          if (LoadLibrary("msftedit.dll") != IntPtr.Zero) {
            cp.ClassName = "RICHEDIT50W";
          }
          return cp;
        }
      }
      [Browsable(false)]
      [DefaultValue(typeof(bool), "False")]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool FreezeDrawing {
        get { return frozen; }
        set {
          if (value != frozen) {
            frozen = value;
            if (frozen) {
              this.SuspendLayout();
              SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
              SendMessage(this.Handle, EM_GETSCROLLPOS, 0, ref lastScroll);
              lastEvent = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
              lastIndex = this.SelectionStart;
              lastWidth = this.SelectionLength;
            } else {
              this.Select(lastIndex, lastWidth);
              SendMessage(this.Handle, EM_SETEVENTMASK, 0, lastEvent);
              SendMessage(this.Handle, EM_SETSCROLLPOS, 0, ref lastScroll);
              SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
              this.Invalidate();
              this.ResumeLayout();
            }
          }
        }
      }
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public Font CurrentFont {
        get {
          Font result = this.Font;
          if (this.SelectionLength == 0) {
            result = SelectionFont;
          } else {
            using (RichBox rb = new RichBox()) {
              rb.FreezeDrawing = true;
              rb.SelectAll();
              rb.SelectedRtf = this.SelectedRtf;
              rb.Select(0, 1);
              result = rb.SelectionFont;
            }
          }
          return result;
        }
      }
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public string SelectionFontName {
        get { return CurrentFont.FontFamily.Name; }
        set {
          CHARFORMAT cf = new CHARFORMAT();
          cf.cbSize = Marshal.SizeOf(cf);
          cf.szFaceName = new char[32];
          cf.dwMask = CFM_FACE;
          value.CopyTo(0, cf.szFaceName, 0, Math.Min(31, value.Length));
          IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
          Marshal.StructureToPtr(cf, lParam, false);
          SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        }
      }
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public float SelectionFontSize {
        get { return CurrentFont.Size; }
        set {
          CHARFORMAT cf = new CHARFORMAT();
          cf.cbSize = Marshal.SizeOf(cf);
          cf.dwMask = CFM_SIZE;
          cf.yHeight = Convert.ToInt32(value * 20);
          IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
          Marshal.StructureToPtr(cf, lParam, false);
          SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        }
      }
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool SelectionBold {
        get { return CurrentFont.Bold; }
        set {
          CHARFORMAT cf = new CHARFORMAT();
          cf.cbSize = Marshal.SizeOf(cf);
          cf.dwMask = CFM_BOLD;
          cf.dwEffects = value ? CFM_BOLD : 0;
          IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
          Marshal.StructureToPtr(cf, lParam, false);
          SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        }
      }
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool SelectionItalic {
        get { return CurrentFont.Italic; }
        set {
          CHARFORMAT cf = new CHARFORMAT();
          cf.cbSize = Marshal.SizeOf(cf);
          cf.dwMask = CFM_ITALIC;
          cf.dwEffects = value ? CFM_ITALIC : 0;
          IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
          Marshal.StructureToPtr(cf, lParam, false);
          SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        }
      }
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool SelectionStrikeout {
        get { return CurrentFont.Strikeout; }
        set {
          CHARFORMAT cf = new CHARFORMAT();
          cf.cbSize = Marshal.SizeOf(cf);
          cf.dwMask = CFM_STRIKE;
          cf.dwEffects = value ? CFM_STRIKE : 0;
          IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
          Marshal.StructureToPtr(cf, lParam, false);
          SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        }
      }
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool SelectionUnderline {
        get { return CurrentFont.Underline; }
        set {
          CHARFORMAT cf = new CHARFORMAT();
          cf.cbSize = Marshal.SizeOf(cf);
          cf.dwMask = CFM_UNDERLINE;
          cf.dwEffects = value ? CFM_UNDERLINE : 0;
          IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
          Marshal.StructureToPtr(cf, lParam, false);
          SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
        }
      }
    }
