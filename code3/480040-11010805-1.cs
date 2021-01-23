    public class Program
    {
        public static void Run()
        {
            ByteElement data = ByteElement.Create("Element");
            ByteElement parI = ByteElement.CreateParam("IntElement", 22);
            ByteElement parD = ByteElement.CreateParam("DblElement", 3.14);
            ByteElement locl = ByteElement.CreateLocal("LocalElement");
        }
    }
