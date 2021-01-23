    public class ocrVar
    {
        static ocrVar()
        {
            DueDate = new Element();
            AmountDue =new Element();
            BillDate = new Element();
        }
        public static Element DueDate { get;private set; }
        public static Element AmountDue { get; private set; }
        public static Element BillDate { get; private set; }
    }
