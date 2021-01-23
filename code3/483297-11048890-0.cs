    public class GameObject
    {
        protected static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
    
        protected string fileName;
        protected Sprite sprite;
    
        public void LoadContent(ContentManager contentManager)
        {
            lock (sprites)
            {
                if (sprites.ContainsKey(fileName))
                    sprite = sprites[fileName];
                else
                    sprites.Add(fileName, mSprite.Load(theContentManager, filename));
            }
        }
    
        public GameObject(string fileName)
        {
            this.fileName = fileName;
        }
    }
