    abstract class Base_Collection
    {
        public int id = 0;
        public string title = "";
        public Base_Collection()
        {
        }
        public virtual void PerformAction(){ } // or public virtual void PerformAction(){ }
    }
    class Book : Base_Collection
    {
        public Book()
        {
        }
        public override void PerformAction()
        {
            // read book
        }
    }
    
    class Game : Base_Collection
    {
        public Game()
        {
        }
        public override void PerformAction()
        {
            // play game
        }
    }
    class Movie : Base_Collection
    {
        public Movie()
        {
        }
        public void PerformAction()
        {
            // watch movie
        }
    }
