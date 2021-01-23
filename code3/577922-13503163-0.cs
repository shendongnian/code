        class Gamebot : GameObject
    {
        static Texture2D DefaultTexture;
        public virtual Texture2D Texture {get{return Gamebot.DefaultTexture;}}
        
        //etc...
        internal bool DidHitEnemy(Gamebot enemyGameBot)
        {
          //  enemyGameBot.Texture; // this will give you the texture of the enemyGameBot 
        }
    }
    class SmartBot : Gamebot
    {
        static new Texture2D DefaultTexture;
        public override Texture2D Texture { get { return SmartBot.DefaultTexture; } }
    }
