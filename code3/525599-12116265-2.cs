    class Program
    {
        static void Main(string[] args)
        {
            IStringComplexity c = new GZipStringComplexity();
    
            string input1 = "HHHFHHFFHHFHHFFHHFHHHFHAAAAHHHFHHFFHHFHHFFHHFHHHFHAAAAHHHFHHFFHHFHHFFHHFHHHFHAAAAHHHFHHFFHHFHHFFHHFHHHFH";
            string input2 = "mlcllltlgvalvcgvpamdipqtkqdlelpklagtwhsmamatnnislmatlkaplrvhitsllptpednleivlhrwennscvekkvlgektenpkkfkinytvaneatlldtdydnflflclqdtttpiqsmmcqylarvlveddeimqgfirafrplprhlwylldlkqmeepcrf";
            string inputMax = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                
            double ratio1 = c.GetCompressionRatio(input1); //2.9714285714285715
            double ratio2 = c.GetCompressionRatio(input2); //1.3138686131386861
            double ratioMax = c.GetCompressionRatio(inputMax); //7.5
    
            double complexity1 = c.GetRelevantComplexity(1, ratioMax, ratio1); // ~ 0.54
            double complexity2 = c.GetRelevantComplexity(1, ratioMax, ratio2); // ~ 0.80
        }
    }
