    class A
    {
        string[] words0 = { "Zero ", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ", "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen ", "Twenty " };
        string[] words2 = { "Zero ", "Ten ", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety ", "Hundred " };
        string[] words3 = { "Hundred ", "Thousand ", "Lakh ", "Crore " };
        int[] numbers = new int[] { 0, 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
        string numstr;
        string words = "";
        int tempNum;
        int temp = 0;
        public void ConvertToRupee(int number)
        {
            numstr = number.ToString();
            words = "";
            tempNum = number;
            temp = 0;
            while (numstr != "0" && numstr.Length != 0)
            {
                switch (numstr.Length)
                {
                    case 1:
                        words += words0[tempNum];
                        numstr = "";
                        break;
                    case 2:
                        if (tempNum <= 20)
                        {
                            words += words0[tempNum];
                            numstr = "";
                        }
                        else
                        {
                            temp = tempNum / numbers[2];
                            words += words2[temp];
                            tempNum = tempNum % numbers[2];
                            numstr = tempNum.ToString();
                        }
                        break;
                    case 3:
                        Method1(3, "Hundred ");
                        break;
                    case 4:
                        Method1(4, "Thousand ");
                        break;
                    case 5:
                        Method2(4, "Thousand ");
                        break;
                    case 6:
                        Method1(6, "Lakh ");
                        break;
                    case 7:
                        Method2(6, "Lakh ");
                        break;
                    case 8:
                        Method1(8, "Crore ");
                        break;
                    case 9:
                        Method2(8, "Crore ");
                        break;
                    default:
                        break;
                }
            }
            words += "Rupees Only ";
            Console.WriteLine(number.ToString() + " : " + words);
        }
        private void Method1(int n, string wo)
        {
            temp = tempNum / numbers[n];
            words += words0[temp] + wo;
            tempNum = tempNum % numbers[n];
            numstr = tempNum.ToString();
        }
        private void Method2(int n, string wo)
        {
            temp = tempNum / numbers[n];
            if (temp == 10)
                words += words0[temp] + wo;
            else if (temp <= 20)
                words += words0[temp] + wo;
            else
            {
                int twoDig = temp / numbers[2];
                int digit = temp % numbers[2];
                words += words2[twoDig] + words0[digit] + wo;
            }
            tempNum = tempNum % numbers[n];
            numstr = tempNum.ToString();
        }
    }
