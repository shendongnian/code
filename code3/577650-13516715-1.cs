    public class CoClassComRef<T> : ComRef<T> where T : class, new()
    {
        public CoClassComRef() : base(new T())
        {
        }
    }
    
    public class Test
    {
        static void Main()
        {
            using (var comRef = new CoClassComRef<Excel.Application>())
            {
                var excel = comRef.Reference;
                // ...
                excel.Quit();
            }
        }
    }
