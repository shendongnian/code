    public interface IConditional
    {
        void AddIndex(int i);
    }
    private class Conditional16 : IConditional
    {
        List<Int16> _list = new List<Int16>();
        
        public void AddIndex(int i)
        {
            _list.Add((short)i);
        }
    }
    private class Conditional32 : IConditional
    {
        List<Int32> _list = new List<Int32>();
        
        public void AddIndex(int i)
        {
            _list.Add(i);
        }
    }
    public static class ConditionalFactory
    {
        public static IConditional Create(bool is16Bit)
        {
            if (is16Bit)
            {
                return new Conditional16();
            }
            else
            {
                return new Conditional32();
            }
        }
    }
