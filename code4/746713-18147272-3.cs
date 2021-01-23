    public interface IBase<T>
    {
         List<T> GetAll();
         void SaveAll(List<T> items);
    }
    
    public class RepA : IBase<RepA> 
    {
        public List<RepA> GetAll() { return new List<RepA>(); }
        public void SaveAll(List<RepA> repA) { }
    }
    public class RepB : IBase<RepB> 
    {
        public List<RepB> GetAll() { return new List<RepB>(); }
        public void SaveAll(List<RepB> repB) { }
    }
    void Main() 
    {
        IBase chosenType = RandomChosenType();
        var list = chosenType.GetAll();
    }
