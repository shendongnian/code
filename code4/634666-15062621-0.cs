    _image = new Bitmap(100, 100); // Image and panel have same size.
    var imageGraphics = Graphics.FromImage(_image);
    imageGraphics.FillEllipse(Brushes.Red, 10, 10, 50, 50); // Some irregular image.
    panel2.Size = new Size(100, 100);
    panel2.BackColor = Color.Transparent; // Panel's background color is transparent.
    _panelGraphics = panel2.CreateGraphics();
