    private void PrintPage(object o, PrintPageEventArgs e)
    {
      string filepath = "D:\\patient images\\" + txtPatCode.Text + "\\" + lstImages.SelectedItems[0].Text;
      System.Drawing.Image img = Image.FromFile(filepath);
      ResizeImage(img, 200);
      Point loc = new Point(200, 200);
      e.Graphics.DrawImage(img, loc);           
    }
    public static Image ResizeImage(Image img, int minsize)
    {
      var size = img.Size;
      if (size.Width >= size.Height)
      {
        // Could be: if (size.Height < minsize) size.Height = minsize;
        size.Height = minsize;
        size.Width = (size.Height * img.Width + img.Height - 1) / img.Height;
      }
      else
      {
        size.Width = minsize;
        size.Height = (size.Width * img.Height + img.Width - 1) / img.Width;
      }
      return new Bitmap(img, size);
    }
