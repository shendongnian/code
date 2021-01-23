     /// <summary>
        /// Formatting a given number to 0,00
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        string NumberFormatting(string number)
        {
            if (number.Contains(','))
            {
                string[] str = number.Split(',');
                if (str[1].Length == 1)
                {
                    number += "0";
                }
            }
            else
            {
                number += ",00";
            }
            return DecreaseNumberDigits(number);
        }
        /// <summary>
        /// To allow only two digits after the decimal mark
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        string DecreaseNumberDigits(string number)
        {
            if (number.Contains(','))
            {
                string[] str = number.Split(',');
                if (str[1].Length > 2)
                    number = str[0] + "," + str[1].ToCharArray()[0].ToString() + str[1].ToCharArray()[1].ToString();
            }
            return number;
        }
