    public abstract class Base_Collection
    {
        public int id = 0;
        public string title = "";
        public Base_Collection() {   }
        public abstract void Consume();
    }
    public class Book : Base_Collection
    {
        public Book() {   }
        public override void Consume()
        {
            //do book reading stuff in here
        }
    }
    public class Movie : Base_Collection
    {
        public Movie() {   }
        public override void Consume()
        {
            //do movie watching stuff in here
        }
    }
    public class SomeOtherClass
    {
        public void SomeMethod(Base_Collection mediaItem)
        {
            //note that the book/movie/whatever was passed as the base type
            mediaItem.Consume();
        }
    }
