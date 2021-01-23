    // Image objects to act as layers (which will hold the images to be composed)
    Image Layer0 = new Bitmap(Application.StartupPath + "\\Res\\base.png");
    Image Layer1 = new Bitmap(Application.StartupPath + "\\Res\\layer1.png");
    //Creating the Canvas to draw on (I'll be saving/using this)
    Image Canvas = new Bitmap(222, 225);
    //Frame to define the dimentions
    Rectangle Frame = new Rectangle(0, 0, 222, 225);
    //To do drawing and stuffs
    Graphics Artist = Graphics.FromImage(Canvas);
    //Draw the layers on Canvas
    Artist.DrawImage(Layer0, Frame, Frame, GraphicsUnit.Pixel);
    Artist.DrawImage(Layer1, Frame, Frame, GraphicsUnit.Pixel);
    //Show the Canvas in a PictureBox
    pictureBox1.Image = Canvas;
    //Save the Canvas image
    Canvas.Save("MYIMG.PNG", ImageFormat.Png);
    
