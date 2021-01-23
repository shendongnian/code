    public interface IPay
    {
        public void Pay(Individual i);
    }
    
    public class MySelf : IPay
    {
        public void Pay(Individual i)
        {
            ...
        }
    }
    public interface ILend
    {
        public void Lend(Individual i);
    }
    
    public class Jack : ILend //Same applies for Ben
    {
        public void Lend(Individual i)
        {
            ...
        }
    }
