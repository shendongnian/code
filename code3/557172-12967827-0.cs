	void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
	{
		Bitmap video = (Bitmap)eventArgs.Frame.Clone();
		pictureBox1.Invoke((Action)(() =>
		{
			pictureBox1.Image = video;
			TextBox1.text = "demo error";
		}));
	}
