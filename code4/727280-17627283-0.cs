    public partial class _Default : System.Web.UI.Page {
        const string BITMAP_ID_BLOCK = "BM";
        const string JPG_ID_BLOCK = "\u00FF\u00D8\u00FF";
        const string PNG_ID_BLOCK = "\u0089PNG\r\n\u001a\n";
        const string GIF_ID_BLOCK = "GIF8";
        const string TIFF_ID_BLOCK = "II*\u0000";
        const int DEFAULT_OLEHEADERSIZE = 78;
        public static byte[] ConvertOleObjectToByteArray(object content) {
            if (content != null && !(content is DBNull)) {
                byte[] oleFieldBytes = (byte[])content;
                byte[] imageBytes = null;
                // Get a UTF7 Encoded string version
                Encoding u8 = Encoding.UTF7;
                string strTemp = u8.GetString(oleFieldBytes);
                // Get the first 300 characters from the string
                string strVTemp = strTemp.Substring(0, 300);
                // Search for the block
                int iPos = -1;
                if (strVTemp.IndexOf(BITMAP_ID_BLOCK) != -1) {
                    iPos = strVTemp.IndexOf(BITMAP_ID_BLOCK);
                } else if (strVTemp.IndexOf(JPG_ID_BLOCK) != -1) {
                    iPos = strVTemp.IndexOf(JPG_ID_BLOCK);
                } else if (strVTemp.IndexOf(PNG_ID_BLOCK) != -1) {
                    iPos = strVTemp.IndexOf(PNG_ID_BLOCK);
                } else if (strVTemp.IndexOf(GIF_ID_BLOCK) != -1) {
                    iPos = strVTemp.IndexOf(GIF_ID_BLOCK);
                } else if (strVTemp.IndexOf(TIFF_ID_BLOCK) != -1) {
                    iPos = strVTemp.IndexOf(TIFF_ID_BLOCK);
                }
                // From the position above get the new image
                if (iPos == -1) {
                    iPos = DEFAULT_OLEHEADERSIZE;
                }
                //Array.Copy(
                imageBytes = new byte[oleFieldBytes.LongLength - iPos];
                MemoryStream ms = new MemoryStream();
                ms.Write(oleFieldBytes, iPos, oleFieldBytes.Length - iPos);
                imageBytes = ms.ToArray();
                ms.Close();
                ms.Dispose();
                return imageBytes;
            }
            return null;
        }
    }
