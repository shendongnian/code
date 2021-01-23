    public interface IAA
    {
        string NameOfA { get; set; }
    }
    public class AA : IAA
    {
        public string NameOfA{get;set;}
    }
    public interface IBB
    {
        string NameOfB { get; set; }
    }    
    public class BB : IBB
    {
        public string NameOfB{get;set;}
    }
    public class CC : IAA, IBB
    {
        private IAA a;
        private IBB b;            
        public CC()
        {
            a = new AA{ NameOfA="a"};
            b = new BB{ NameOfB="b"};
        }
        public string NameOfA{
            get{
                return this.a.NameOfA;
               }
            set{
                this.a.NameOfA = value;
               }
        }
        public string NameOfB
        {
            get{
                return this.b.NameOfB;
            }
            set{
                this.b.NameOfB = value;
            }
        }
    }
