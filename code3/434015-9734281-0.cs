    public class Sprite : IAnimatable
    {
        private Texture2D rings;
    
        public void LoadContent(ContentManager Content)
        {
            // Call this method from Game.LoadContent()
            rings = Content.Load<Texture2D>("Images/threerings");
        }
    
    public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAnimating)
            {
                // Incorporate IAnimatable variables here to draw your animation
            }
        }
    
    }
    public interface IAnimatable
    {
        public bool IsAnimating {get; set;}
        public int CurrentFrameIndex {get; set;}
        public Point FrameSize {get; set;}
    }
