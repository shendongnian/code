    abstract class GameObject
    {
        public abstract void Move();
        public abstract void Draw(Graphics g);
    }
    class Pacman : GameObject
    {
        public override void Move()
        {
            //Update the Position of Pacman, check for collisions, ...
        }
        public override void Draw(Graphics g)
        {
            //Draw Pacman at his x and y coordinates
        }
    }
    class Monster : GameObject
    {
        public override void Move()
        {
            //Update the Position of the Monster, ...   
        }
        public override void Draw(Graphics g)
        {
            //Draw the Monster at his current position
        }
    }
    class GameClass
    {
        private Pacman _pacman;
        private Monster _monster;
        private List<GameObject> _gameobjects = new List<GameObject>();
        public GameClass()
        {
            _pacman = new Pacman();
            _monster = new Monster();
            _gameobjects.Add(_pacman);
            _gameobjects.Add(_monster);
        }
        private void TimerTick()
        {
            //update all GameObjects
            foreach (var gameobject in _gameobjects)
            {
                gameobject.Move();
            }
            //Draw every single GameObject to the Bitmap
            Bitmap bitmap = new Bitmap(panBox.Width, panBox.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (var gameobject in _gameobjects)
                {
                    gameobject.Draw(g);
                }
            }
            //Draw the Bitmap to the screen
            using (Graphics g = panBox.CreateGraphics())
            {
                g.DrawImage(bitmap, 0, 0);
            }
        }
