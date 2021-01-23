    private static byte[] GetScaledImage( byte[] inputBytes, int width, int height ) {
        Image img = null;
        using( MemoryStream ms = new MemoryStream() ) {
            ms.Write( inputBytes, 0, inputBytes.Length );
            img = Image.FromStream( ms );
        }
        using( MemoryStream ms = new MemoryStream() ) {
            using( Image newImg = new Bitmap( width, height ) ) {
                using( Graphics g = Graphics.FromImage( newImg ) ) {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage( img, 0, 0, width, height );
                    newImg.Save( ms, img.RawFormat );
                    return ms.GetBuffer();
                }
            }
        }
    }
