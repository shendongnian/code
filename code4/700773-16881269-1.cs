    class Program
        {
            static void Main(string[] args)
            {
               var one=new LevelOne();
               Console.WriteLine(one.LevelTwo.LevelThree.LastLevel);
              
            }
        }
    
        internal class LevelOne
        {
            public LevelOne()
            {
                LevelTwo = LevelTwo ?? new LevelTwo();
            }
            public LevelTwo LevelTwo { get; set; }
        }
        internal class LevelTwo
        {
            public LevelTwo()
            {
                LevelThree = LevelThree ?? new LevelThree();
            }
            public LevelThree LevelThree { get; set; }
        }
        internal class LevelThree
        {
            private string _lastLevel="SimpleString";
            public String LastLevel { get { return _lastLevel; } set { _lastLevel = value; } }
        }
