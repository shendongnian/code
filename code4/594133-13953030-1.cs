    static void Main(string[] args)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        SomeFunction(ref dialog);
    }
    static void SomeFunction(ref FileDialog obj)
    {
        obj = new SaveFileDialog();
    }
