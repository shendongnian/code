    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    namespace Mobile.Util
    {
        public class BarcodeUtil
        {
            public static string AI_SSCC = "00";
            public static string AI_GTIN = "01";
            public static string AI_GTIN_B = "02";
            public static string AI_LOT_NUMBER = "10";
            public static string AI_DATE_PRODUCTION = "11";
            public static string AI_DATE_DUE = "12";
            public static string AI_DATE_PACKING = "13";
            public static string AI_DATE_BEST_BEFORE = "15";
            public static string AI_DATE_SELL_BY = "16";
            public static string AI_DATE_EXPIRATION = "17";
            public static string AI_PRODUCT_VARIANT = "20";
            public static string AI_SERIAL_NUMBER = "21";
            public static int AI_TYPE_DATE = 1;
            public static int AI_TYPE_ALPHANUMERIC = 2;
            public static int AI_TYPE_NUMERIC = 3;
            public class AII
            {
                public string AICode { set; get; }
                public string AIDesc { set; get; }
                public int minLength { set; get; }
                public int maxLength { set; get; }
                public int type { set; get; }
                public string AIValue { set; get; }
                public AII(string aicode, string aiDesc, int minLen, int maxLen, int type)
                {
                    this.AICode = aicode;
                    this.AIDesc = aiDesc;
                    this.minLength = minLen;
                    this.maxLength = maxLen;
                    this.type = type;
                    this.AIValue = "";
                }
                public AII(AII ai)
                {
                    this.AICode = ai.AICode;
                    this.AIDesc = ai.AIDesc;
                    this.minLength = ai.minLength;
                    this.maxLength = ai.maxLength;
                    this.type = ai.type;
                    this.AIValue = ai.AIValue;
                }
            }
            public static Dictionary<string, AII> GS1_AI = new Dictionary<string, AII>() { //AI, description, min length, max length, type, decimal point indicator? 
                            {AI_SSCC, new AII(AI_SSCC, "SSCC",18, 18, AI_TYPE_NUMERIC)},
                            {AI_GTIN,new AII(AI_GTIN, "Identification of a Variable Measure Trade Item (GTIN)", 14,14, AI_TYPE_NUMERIC)},
                            {AI_GTIN_B,new AII( AI_GTIN_B, "Identification of Variable Measure Trade Items Contained in a Logistic", 14, 14, AI_TYPE_NUMERIC)},
                            {AI_LOT_NUMBER,new AII( AI_LOT_NUMBER, "Batch or lot number",1, 20, AI_TYPE_ALPHANUMERIC)},
                            {AI_DATE_PRODUCTION,new AII(  AI_DATE_PRODUCTION, "Production Date",6, 6, AI_TYPE_NUMERIC)},//YYMMDD day not mandatory 00
                            {AI_DATE_DUE,new AII( AI_DATE_DUE, "Due Date for Amount on Payment Slip",6, 6, AI_TYPE_NUMERIC)}, //YYMMDD day not mandatory 00
                            {AI_DATE_PACKING,new AII( AI_DATE_PACKING, "Packaging Date",6, 6, AI_TYPE_NUMERIC)},//YYMMDD day not mandatory 00
                            {AI_DATE_BEST_BEFORE,new AII( AI_DATE_BEST_BEFORE, "Best before date", 6, 6, AI_TYPE_NUMERIC)},//YYMMDD day not mandatory 00
                            {AI_DATE_SELL_BY,new AII( AI_DATE_SELL_BY, "Sell By Date", 6, 6, AI_TYPE_NUMERIC)},//YYMMDD day not mandatory 00
                            {AI_DATE_EXPIRATION,new AII( AI_DATE_EXPIRATION, "Expiration Date", 6, 6, AI_TYPE_NUMERIC)},//YYMMDD day not mandatory 00
                            {AI_PRODUCT_VARIANT,new AII( "20", "Product Variant", 2, 2, AI_TYPE_ALPHANUMERIC)},
                            {AI_SERIAL_NUMBER,new AII( AI_SERIAL_NUMBER, "Serial Number",1, 20, AI_TYPE_ALPHANUMERIC)}, 
                                    //{AI_,new AII( "240", "Additional Product Identification Assigned by the Manufacturer", 1, 30, AI_TYPE_ALPHANUMERIC}, 
                                    //{AI_,new AII( "241", "Customer Part Number",1,30, AI_TYPE_ALPHANUMERIC)}, 
                                  
                                    //{AI_,new AII( "37", "Number of units contained", 1, 8, AI_TYPE_NUMERIC)},
                                    //{AI_,new AII( "400", "Customer's purchase order number", 1, 29, AI_TYPE_ALPHANUMERIC)},
                                    //{AI_,new AII( "8005", "Price per unit of measure", 6, 6, AI_TYPE_NUMERIC)},
                                    //{AI_,new AII( "310", "Netto weight in kilograms", 7, 7, AI_TYPE_NUMERIC)},
                                    //{AI_,new AII( "315", "Netto volume in liters", 7, 7, AI_TYPE_NUMERIC)},
                           };
            public static Dictionary<string, string> decodeBarcodeGS1_128(string barcode)
            {
                Dictionary<string, string> barcode_decoded = new Dictionary<string, string>();
                barcode = barcode.Replace(")", "").Replace("(", "");
                foreach (KeyValuePair<string, AII> entry in GS1_AI)
                {
                    string strAI = entry.Value.AICode;
                    int intMin = entry.Value.minLength;
                    int intMax = entry.Value.maxLength;
                    int strType = entry.Value.type;
                    string strRegExMatch = "";
                    string matchString;
                    if (strType == AI_TYPE_ALPHANUMERIC)
                    {
                        strRegExMatch = Regex.Match(barcode, strAI + @"\w{" + intMin + "," + intMax + "}").ToString();
                    }
                    else if (strType == AI_TYPE_NUMERIC)
                    {
                        strRegExMatch = Regex.Match(barcode, strAI + @"\d{" + intMin + "," + intMax + "}").ToString();
                    }
                    if (strRegExMatch.Length > 0)
                    {
                        barcode = Regex.Replace(barcode, strRegExMatch, ""); //remove the AI and its value so that its value can't be confused as another AI
                        var regex = new Regex(Regex.Escape(strAI));
                        strRegExMatch = regex.Replace(strRegExMatch, "", 1);
                        barcode_decoded.Add(strAI, strRegExMatch);
                    }
                }
                return barcode_decoded;
            }
        }
    }
