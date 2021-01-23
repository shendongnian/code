    public interface IBase<T>
    {
         void GetAll();
         void SaveAll(List<T>);
    }
    
    public class RepA : IBase {
        public void GetAll() { }
        public void SaveAll(List<RepA> repA) { }
    }
    public class RepB : IBase {
        public void GetAll() { }
        public void SaveAll(List<RepB> repB) { }
    }
    void Main() {
        IBase chosenType = RandomChosenType();
        chosenType.GetAll();
    }
