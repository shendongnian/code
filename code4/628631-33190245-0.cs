            if (lastNum > dec)
                return lastDec - dec;
            else return lastDec + dec;
        }
        public static int ConvertRomanNumtoInt(string strRomanValue)
        {
            var dec = 0;
            var lastNum = 0;
            foreach (var c in strRomanValue.Reverse())
            {
                switch (c)
                {
                    case 'I':
                        dec = pairConversion(1, lastNum, dec);
                        lastNum = 1;
                        break;
                    case 'V':
                        dec=pairConversion(5,lastNum, dec);
                        lastNum = 5;
                        break;
                    case 'X':
                        dec = pairConversion(10, lastNum, dec);
                        lastNum = 10;
                        break;
                    case 'L':
                        dec = pairConversion(50, lastNum, dec);
                        lastNum = 50;
                        break;
                    case 'C':
                        dec = pairConversion(100, lastNum, dec);
                        lastNum = 100;
                        break;
                    case 'D':
                        dec = pairConversion(500, lastNum, dec);
                        lastNum = 500;
                        break;
                    case 'M':
                        dec = pairConversion(1000, lastNum, dec);
                        lastNum = 1000;
                        break;
                }
            }
            return dec;
            
        }
