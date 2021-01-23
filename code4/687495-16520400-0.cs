        public static List<string> ProcessStrings(List<int> intList)
        {
            return intList.ConvertAll<string>(new Converter<int, string>(
             delegate(int number)
             {
                  return number.ToString();
             }));
        }
