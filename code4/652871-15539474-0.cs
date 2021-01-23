    interface iEnemy
    {
        public void Move();
    }
    
    class Troll : iEmeny
    {
        public void Move()
        {
           Console.WriteLine("troll moves!");
        }
    }
    
    class Ogre : iEmeny
    {
        public void Move()
        {
           Console.WriteLine("ogre moves!");
        }
    }
