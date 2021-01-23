    public class CClass : IDemoralize
    {
        public IDemoralizeBase MyDemoralizer {get; private set;}
    
        public CClass(IDemoralizeBase basicDemoralizer)
        {
            MyDemoralizer = basicDemoralizer;
        }
    
        public void Demoralize(Func<IDemoralize, bool> CustomDemoralization)
        {
            MyDemoralizer.Demoralize(CustomDemoralization);
        }
    
        public void WriteModel(Func<IDemoralize, bool> Write)
        {
            MyDemoralizer.WriteModel(Write);
        }
    }
