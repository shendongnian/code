    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
         Bitmap newbitmap = (Bitmap)e.Argument;
    
         int tmax = 10;
         int xmax = newbitmap.Width;
         int ymax = newbitmap.Height;
         for (int t = 0; t <= tmax; t += 1)
         {
    
             for (int x = 0; x < xmax; x++)
             {
                  for (int y = 0; y < ymax; y++)
                  {
                       if ((x / xmax) > (t / tmax))
                       {
                           Color originalco = newbitmap2.GetPixel(x, y);
                           outp.SetPixel(x, y, originalco);
                       }
                       else
                       {
                           Color originalco3 = newbitmap.GetPixel(x, y); ;
                           outp.SetPixel(x, y, originalco3);
                       }
    
                   }
                   pictureBox1.Image = outp;
             }
          }
          bgWorker.ReportProgress(0,outp);
    }
