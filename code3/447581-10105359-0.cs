      using DataMatrix.net;               // Add ref to DataMatrix.net.dll
      using System.Drawing;               // Add ref to System.Drawing.
      [...]
    
      // ---------------------------------------------------------------
      // Date      180310
      // Purpose   Get text from a DataMatrix image.
      // Entry     sFileName - Name of the barcode file (PNG, + path).
      // Return    The text.
      // Comments  See source, project DataMatrixTest, Program.cs.
      // ---------------------------------------------------------------
      private string DecodeText(string sFileName)
      {
          DmtxImageDecoder decoder = new DmtxImageDecoder();
          System.Drawing.Bitmap oBitmap = new System.Drawing.Bitmap(sFileName);
          List<string> oList = decoder.DecodeImage(oBitmap);
    
          StringBuilder sb = new StringBuilder();
          sb.Length = 0;
          foreach (string s in oList)
          {
              sb.Append(s);
          }
          return sb.ToString();
      }
