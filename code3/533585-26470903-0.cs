    try
    {
       TcpListener srv = new TcpListener(IPAddress.Any, 51530);
       srv.Start(1);
       TcpClient client = srv.AcceptTcpClient();
       NetworkStream ns = client.GetStream();
       Rectangle screenshot;
       Bitmap bitmap;
       screenshot = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
       bitmap = new Bitmap(screenshot.Width, screenshot.Height, PixelFormat.Format32bppArgb);
       Graphics g = Graphics.FromImage(bitmap);
       g.CopyFromScreen(screenshot.Left, screenshot.Top, 0, 0, screenshot.Size);
       g.Dispose();
       MemoryStream m = new MemoryStream();
       //you can also just save to network stream and skip the copy but i kept it for demo
       bitmap.Save(m, ImageFormat.Jpeg);
       
       //reset the memory stream to start of stream
       m.Position = 0;
       //copy memory stream to network stream
       m.CopyTo(ns);
       //make sure copy is completed
       m.Flush();
       m.Close();
       
       //Makes sure everything is sent before closing it
       ns.Flush();
       
       //The Image.FromStream() seems to wait for the stream to be finished/closed.
       client.Close();
    }
    catch (Exception ex)
    {
       Console.WriteLine(ex.ToString());
       Console.ReadKey();
    }
