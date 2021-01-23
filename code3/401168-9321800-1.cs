    public interface ICar
    {
        IDoor Door { get; set; } 
    }
    
    public class Car : ICar
    {
        public IDoor Door { get; set; }
    }
    
    public interface IDoor
    {
        void Open();
        void Close();
    }
    
    public class Door : IDoor
    {
        public override void Open() { /* do something */ }
        public override void Close() { /* do something */ }
    }
