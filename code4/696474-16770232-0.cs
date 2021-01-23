    public class RobotManager
    {
        private SpriteBatch spriteBatch;
        private Texture2D robotTexture;
    
        private List<Robot> robots;
    
        public RobotManager(SpriteBatch spriteBatch, Texture2D texture)
        {
            this.spriteBatch = spriteBatch;
            this.robotTexture = texture;
    
            robots = new List<Robot>();
        }
    
        public void Update()
        {
            foreach (var robot in robots)
                robot.Update();
        }
    
        public void Draw()
        {
            foreach (var robot in robots)
                robot.Draw();
        }
    
        public void AddRobot(Vector2 position, Texture2D customTexture = null)
        {
            //Creates a new robot with position set and custom texture if specified
            var newRobot = new Robot(spriteBatch, position, (customTexture == null) ? robotTexture : customTexture);
            robots.Add(newRobot);
        }
    
    }
