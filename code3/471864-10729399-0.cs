    namespace ConsoleApplication1
    {
    
        abstract class Base 
        {     
            protected abstract bool Changed<T>(T obj) where T : Base;      
            public bool Changed()     
            {         
                return Changed(this);     
            }
            public String PropBase { get; set; }
        }  
    
        class SubclassA : Base 
        {
            public String PropA { get; set; }
            protected override bool Changed<SubclassA>(SubclassA obj)     
            {
                ConsoleApplication1.SubclassA myInstance = obj as ConsoleApplication1.SubclassA;
                // Now can see PropA
                myInstance.PropA = "A";
                return true;
            }
        }
        class SubclassB : Base
        {
            protected override bool Changed<SubclassB>(SubclassB obj)
            {
                // can't see prop B here 
                // obj.PropB = "B";
                return true;
            }
            public String PropB { get; set; }
        } 
        class Program
        {
            static void Main(string[] args)
            {
                SubclassB x = new SubclassB();
                x.Changed();
                Base y = new SubclassA();
                y.Changed();
            }
        }
    }
