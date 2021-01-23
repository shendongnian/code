    public enum Enum1
    {
        A_VALUE,
        B_VALUE,
        C_VALUE
    }
    public enum Enum2
    {
        VALUE_1,
        VALUE_2,
        VALUE_3
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.EnumMin<Enum1>());
            Console.WriteLine(p.EnumMax<Enum2>());
        }
        T EnumMin<T>()
        {
            T ret; ;
            Array x = Enum.GetValues(typeof(T));
            ret  = (T) x.GetValue(0);
            return ret;
        }
        T EnumMax<T>()
        {
            T ret; ;
            Array x = Enum.GetValues(typeof(T));
            ret = (T)x.GetValue(x.Length-1);
            return ret;
        }
    }
