    private void timer1_Tick(object sender, EventArgs e)
    {
       Icon icon;
       
       // Create a temporary new Bitmap, and fill it with a random numeric value.
       using (Bitmap bmp = new Bitmap(SystemInformation.SmallIconSize.Width, SystemInformation.SmallIconSize.Height))
       {
          Graphics g = Graphics.FromImage(bmp);
          g.DrawString(rnd.Next().ToString(),
                       SystemFonts.MessageBoxFont,
                       SystemBrushes.ControlText,
                       0.0F, 0.0F);
    
          // Convert this bitmap to an icon.
          icon = Icon.FromHandle(bmp.GetHicon());
       }
       
       // Update the notification icon to use our new icon,
       // and destroy the old icon so we don't leak memory.
       Icon oldIcon = notifyIcon1.Icon;
       notifyIcon1.Icon = icon;
       oldIcon.Dispose();
    }
    
