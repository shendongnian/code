    public class Program
    {
        public static void Main1()
        {
            Number myNumber = new Number(100000);
            myNumber.PrintMoney();
            myNumber.PrintNumber();
            Console.ReadKey();
        }
    }
    public class Number
    {
        private PrintHelper _printHelper;
        public Number(int val)
        {
            _value = val;
            _printHelper = new PrintHelper();
            //subscribe to beforePrintEvent event
            _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
        }
        //beforePrintevent handler
        void printHelper_beforePrintEvent(string message)
        {
            Console.WriteLine("BeforePrintEvent fires from {0}", message);
        }
        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public void PrintMoney()
        {
            _printHelper.PrintMoney(_value);
        }
        public void PrintNumber()
        {
            _printHelper.PrintNumber(_value);
        }
    }
    public class PrintHelper
    {
        public delegate void BeforePrintDelegate(string message);
        public event BeforePrintDelegate beforePrintEvent;
        public PrintHelper()
        {
        }
        public void PrintNumber(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent.Invoke("PrintNumber");
            Console.WriteLine("Number: {0,-12:N0}", num);
        }
        public void PrintDecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("PrintDecimal");
            Console.WriteLine("Decimal: {0:G}", dec);
        }
        public void PrintMoney(int money)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("PrintMoney");
            Console.WriteLine("Money: {0:C}", money);
        }
        public void PrintTemperature(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("PrintTemerature");
            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }
        public void PrintHexadecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("PrintHexadecimal");
            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }
