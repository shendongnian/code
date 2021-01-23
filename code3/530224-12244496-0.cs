    [DelimitedRecord(",")]
    public class Script
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string Symbol;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string Date;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string Expiry;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string StrikePrice;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string Open;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string High;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string Low;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string Close;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string LTP;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string SettlePrice;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string NoOfContracts;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string TurnOverInLacs;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string OpenInt;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string ChangeInOI;
        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string UnderlyingValue;
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"""Symbol"",""Date"",""Expiry"",""Strike Price"",""Open"",""High"",""Low"",""Close"",""LTP"",""Settle Price"",""No. of contracts"",""Turnover in Lacs"",""Open Int"",""Change in OI"",""Underlying Value """ + Environment.NewLine +
                @"""NIFTY"",""31-Aug-2012"",""27-Sep-2012"","" 5400.00"","" 56.00"","" 56.90"","" 38.05"","" 44.45"","" 43.55"","" 44.45"","" 281087"","" 765592.77"","" 4845150"","" 1334150"","" 5258.50""";
            var engine = new FileHelperEngine<Script>();
            engine.Options.IgnoreFirstLines = 1; // skipping the header line
            Script[] validRecords = engine.ReadString(input);
            // Check the third record
            Assert.AreEqual("NIFTY", validRecords[0].Symbol);
            Assert.AreEqual("31-Aug-2012", validRecords[0].Date);
            Assert.AreEqual("27-Sep-2012", validRecords[1].Date);
            // etc...            
            Console.WriteLine("All assertions passed");
            Console.Read();
        }
    }
