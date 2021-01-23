    class Wizard : DrawableGameComponent {
        Texture2D wizardTexture;
    
        public Wizard(Game game) : base(game)
        {
        }
        protected override void LoadContent()
        {
           wizardTexture = Content.Load<Texture2D>("Wizard"); // Error is here
            base.LoadContent();
        }
        ....
    }
