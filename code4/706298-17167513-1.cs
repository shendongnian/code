    public MainForm()
    {
	InitializeComponent();
	pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
	// use a .gif for 8bpp
	Bitmap bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Forest Flowers.jpg"); 
	pictureBox.Image = bmp;
	_backImageData = GetBitmapData(bmp);
	_drawBitmap = true;
	_thread= new Thread(DrawtoBitmapLoop);
	_thread.IsBackground= true;
	_thread.Start();
		
	button.Text = "Let's get real";
	button.Click += (object sender, EventArgs e) =>
		{
			// OK on my system, it does not rreallocate but ...
			bmp.RotateFlip(RotateFlipType.Rotate180FlipX); 
			// ** FAIL with Rotate180FlipY on my system**		
		};	
    }
    Thread _thread;
    bool _drawBitmap;
    BitmapData _backImageData;
    //Non UI Thread
    private void DrawtoBitmapLoop()
    {
    	while (_drawBitmap)
    	{
    		ScrollColors(_backImageData);
    			
    		this.Invoke((ThreadStart)(() =>
    		{
    			if (!this.IsDisposed)
    				this.pictureBox.Invalidate();
    		}));				
    		Thread.Sleep(100);
    	}
    }
    
    private unsafe static void ScrollColors(BitmapData bmpData)
    {
    	byte* ptr = (byte*)bmpData.Scan0;
    	ptr--;
    	byte* last = &ptr[(bmpData.Stride) * bmpData.Height];
    	while (++ptr <= last)
    	{
    		*ptr = (byte)((*ptr << 7) | (*ptr >> 1));
    	}
    }
