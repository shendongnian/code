    class FrameInfo
    {
       public int Frame{ get; private set; }
       public double Position { get; private set; }
		public FrameInfo(int frame, double position)
		{
			Frame = frame;
			Position = position;
		}
	}
