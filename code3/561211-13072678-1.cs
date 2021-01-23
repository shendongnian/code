    public class Bookland : IDisposable {
      public Image BarCode { get; private set; }
      public byte[] BinaryImage {
        get {
          return ms.ToArray();
        } 
      }
      private StringBuilder BinaryText { get; set; }
      private int LineBuffer { get; set; }
    private MemoryStream ms = new MemoryStream();
    public Bookland(string ISBN) {
      // TODO: Regular Expression Replace all but 0-9
      // TODO: Check Length and Convert 10 to 13 if necessary
      this.BinaryText = new StringBuilder();
      this.LineBuffer = 21;
      char[] isbn = ISBN.ToArray();
      this.BinaryText.Append("101");
      this.CalculateFirstSet(isbn);
      this.BinaryText.Append("01010");
      this.CalculateSecondSet(isbn);
      this.BinaryText.Append("101");
      using (Bitmap bmp = new Bitmap(135, 105, PixelFormat.Format32bppRgb)) {
        using (Pen pen = new Pen(Color.White)) {
          using (Graphics g = Graphics.FromImage(bmp)) {
            g.Clear(Color.White);
            Rectangle r = new Rectangle(10, 72, 10, 15);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString("9", new Font("Courier", 8), Brushes.Black, r);
            r = new Rectangle(26, 72, 42, 15);
            g.DrawString(ISBN.Substring(1, 6), new Font("Courier", 8), Brushes.Black, r);
            r = new Rectangle(72, 72, 42, 15);
            g.DrawString(ISBN.Substring(7, 6), new Font("Courier", 8), Brushes.Black, r);
            g.Flush();
            char[] binary = this.BinaryText.ToString().ToCharArray();
            int[] delim = new int[] { 0, 1, 2, 45, 46, 47, 48, 49, 92, 93, 94 };
            for (int i = 0; i < binary.Length; i++) {
              pen.Color = binary[i] == '1' ? Color.Black : Color.White;
                
              if (delim.Contains(i)) {
                g.DrawLine(pen, this.LineBuffer, 20, this.LineBuffer, 85);
              }
              else {
                g.DrawLine(pen, this.LineBuffer, 20, this.LineBuffer, 70);
              }
              this.LineBuffer++;
            }
          }
        }
        bmp.Save(ms, ImageFormat.Png);
        this.BarCode = Image.FromStream(ms);
      }
    }
    private void CalculateFirstSet(char[] set) {
      for (int i = 1; i <= 6; i++) {
        switch (set[i]) {
          case '0':
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0001101");
            }
            else {
              this.BinaryText.Append("0100111");
            }
            break;
          case '1':
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0011001");
            }
            else {
              this.BinaryText.Append("0110011");
            }
            break;
          case '2':
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0010011");
            }
            else {
              this.BinaryText.Append("0011011");
            }
            break;
          case '3':
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0111101");
            }
            else {
              this.BinaryText.Append("0100001");
            }
            break;
          case '4':
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0100011");
            }
            else {
              this.BinaryText.Append("0011101");
            }
            break;
          case '5':
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0110001");
            }
            else {
              this.BinaryText.Append("0111001");
            }
            break;
          case '6':
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0101111");
            }
            else {
              this.BinaryText.Append("0000101");
            }
            break;
          case '7':
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0111011");
            }
            else {
              this.BinaryText.Append("0010001");
            }
            break;
          case '8':
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0110111");
            }
            else {
              this.BinaryText.Append("0001001");
            }
            break;
          default:
            if (i == 1 || i == 4 || i == 6) {
              this.BinaryText.Append("0001011");
            }
            else {
              this.BinaryText.Append("0010111");
            }
            break;
        }
      }
    }
    private void CalculateSecondSet(char[] set) {
      for (int i = 7; i < set.Length; i++) {
        switch (set[i]) {
          case '0':
            this.BinaryText.Append("1110010");
            break;
          case '1':
            this.BinaryText.Append("1100110");
            break;
          case '2':
            this.BinaryText.Append("1101100");
            break;
          case '3':
            this.BinaryText.Append("1000010");
            break;
          case '4':
            this.BinaryText.Append("1011100");
            break;
          case '5':
            this.BinaryText.Append("1001110");
            break;
          case '6':
            this.BinaryText.Append("1010000");
            break;
          case '7':
            this.BinaryText.Append("1000100");
            break;
          case '8':
            this.BinaryText.Append("1001000");
            break;
          default:
            this.BinaryText.Append("1110100");
            break;
        }
      }
    }
    public void Dispose() {
      this.BarCode.Dispose();
      this.ms.Dispose();
      this.BinaryText = null;
    }
    
