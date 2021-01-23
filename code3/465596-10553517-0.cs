    public class LetterRect : Microsoft.Xna.Framework.GameComponent
    {
        private LetterSquare square1;
        private LetterSquare square2;
        public LetterRect()
        {
            square1 = new InnerClass(this);
            square2 = new InnerClass(this);
        }
    }
    
    public class LetterSquare 
    {
        public LetterRect LetterRectProp { get; private set; }
        public LetterSquare (LetterRect letterRect )
        {
            this.LetterRectProp = letterRect;
        }
    }
