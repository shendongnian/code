    public interface IA
    {
        void Add();
    }
    public class A : IA
    {
        void IA.Add()
        {
            throw new NotImplementedException();
        }
    }
