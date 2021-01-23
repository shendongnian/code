    try
        {
          // System.Drawing.Point p=new System.Drawing.Point(100,500);
            Bitmap b = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics=Graphics.FromImage(b as Image);
            graphics.CopyFromScreen(0,0,0,0,b.Size);
           string stringsFile=@"C:\Image1";
            b.Save(stringsFile,ImageFormat.Png);
         }
      catch (Exception exp)
          {
          Microsoft.Windows.Controls.MessageBox.Show("Opps !!! " + exp.Message);
          } 
