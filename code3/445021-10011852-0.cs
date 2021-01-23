    public interface ISomeInterface
    {
        int test(int a, string b);       
    }
    ISomeInterface instance = GetInstance();
    int i = instance.test(1, "b");
