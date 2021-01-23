    public class MultipleOpjects
    {
        public List<string> ObjectOne { get; set; }
        
        public List<object> ObjectTwo { get; set; }
        
        public object ObjectThree { get; set; }
    }
    public MultipleOpjects GetAnything()
    {
        MultipleOpjects Vrble = new MultipleOpjects();
        Vrble.ObjectOne  = SomeThing1;
        Vrble.ObjectTwo = SomeThing2;
        Vrble.ObjectThree = SomeThing3;
        return Vrble;      
    }
