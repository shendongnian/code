    class Program
    {
        static string MyMember 
        {
           get { return MyClass.MyMember; }
           set { MyClass.MyMember = value; }
        }
        static void Main(string[] args)
        {
            MyMember = "Some value.";
        }
    }
