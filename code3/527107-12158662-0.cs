    using System;
    using FileHelpers;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            public static void Main()
            {
                /*
                Sample data from TestData.csv
                    "Symbol","Date","Expiry","StrikePrice","Open","High","Low","Close"
                    "MSF","20090913","03032012","1.233","1.1","14.54","0.07","14.11"
                    "APL","20111225","31122011","30.09","31.1","33.33","29.11","33.13"
                */
                var engine = new FileHelperEngine<StockModel>();
                engine.Options.IgnoreFirstLines = 1; // skip the header line
                StockModel[] stocks = engine.ReadFile(@"TestData.csv");
                Console.Read();
            }
        }
        [DelimitedRecord(",")]
        public class StockModel
        {
            [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
            public string Symbol;
            [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
            [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
            public DateTime Date;
            [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
            [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
            public DateTime Expiry;
            [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
            [FieldConverter(ConverterKind.Decimal, ".")]
            public decimal StrikePrice;
            [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
            [FieldConverter(ConverterKind.Decimal, ".")]
            public decimal Open;
            [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
            [FieldConverter(ConverterKind.Decimal, ".")]
            public decimal High;
            [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
            [FieldConverter(ConverterKind.Decimal, ".")]
            public decimal Low;
            [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
            [FieldConverter(ConverterKind.Decimal, ".")]
            public decimal Close;
        }
    }
