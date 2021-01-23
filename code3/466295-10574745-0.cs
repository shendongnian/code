    public class Movie : Media<MovieInfo>
    {
        public string FrameHeight
        {
            get { return this.info.FrameHeight; }
        }
    }
