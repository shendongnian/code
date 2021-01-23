    class Main
    {
        public static void Main()
        {
            var spec = new LedgerCodeSpec(LedgerCodes.SUB)
            var blueBank = new Bank(spec);
            
            Console.WriteLine(blueBank.IsValid); // false
            blueBank.LedgerCode = LedgerCodes.RCC | LedgerCodes.SUB;
            
            Console.WriteLine(blueBank.IsValid); // false
            blueBank.LedgerCode = LedgerCodes.SUB;
            
            Console.WriteLine(blueBank.IsValid); // true
        }
    }
