        public static String getWeight(Excel.Border border)
        {
            String retval = "weight = ";
            int weight = border.Weight;
            const int xlThick = (int)Excel.XlBorderWeight.xlThick;
            switch (weight)
            {
                case xlThick:
                    retval += "thick";
                    break;
                //... continue for all border weights
            }
            return retval;
        }
