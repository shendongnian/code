    private Bitmap RotateImage( Bitmap bmp, float angle ) {
         Bitmap rotatedImage = new Bitmap( bmp.Width, bmp.Height );
         using ( Graphics g = Graphics.FromImage( rotatedImage ) ) {
            g.TranslateTransform( bmp.Width / 2, bmp.Height / 2 ); //set the rotation point as the center of your image
            g.RotateTransform( angle ); //rotate
            g.TranslateTransform( -bmp.Width / 2, -bmp.Height / 2 ); //restore rotationpoint into the matrix
            g.DrawImage( bmp, new Point( 0, 0 ) ); //draw the image on the new bitmap
         }
         return rotatedImage;
    }
