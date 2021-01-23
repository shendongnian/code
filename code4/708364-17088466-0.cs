     private void TheBalls_Paint(object sender, PaintEventArgs e)
     {
         Bitmap bitmap = new Bitmap(yourBall.Center.X * 2, yourBall.Center.Y * 2);
         flagGraphics = Graphics.FromImage(bitmap);
         foreach (var ball in list)
         {
             ball.Update(flagGraphics);
         }
         e.Graphics.DrawImage(bitmap, 0, 0);
     }
