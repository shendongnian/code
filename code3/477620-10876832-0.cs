    abstract class MyBase
    {
        public abstract String l_strChildName { get; }
    }
    class MyChild_One : MyBase
    {
        public override String l_strChildName 
        { 
            get { return "MyChild One"; }
        }
    }
    class MyChild_Two : MyBase
    {
        public override String l_strChildName 
        { 
            get { return "MyChild Two"; }
        }
    } 
