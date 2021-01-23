	class LevelOne
    {
        public virtual void SayHi()
        {
            Console.WriteLine("Hi!");
        }
    }
    class LevelTwo : LevelOne
    {
        override void SayHi()
        {
            Console.WriteLine("Hi!");
        }
    }
    class LevelThree : LevelTwo
    {
        override void SayHi()
        {
            Console.WriteLine("Hi!");
        }
    }
