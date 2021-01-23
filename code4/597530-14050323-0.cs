    class Program
    {
        //This can be included in Seprate class also
        public enum ErrorMessages
        {
            //Store any Values as Key and Pair
            // Provide and easy way to update answers
            Error1 = 1,
            Error2 = 2,
            Error3 = 3,
            Error4 = 4
        }
        public static void Main()
        {
            ICollection<EnumValueDto> list = EnumValueDto.ConvertEnumToList<ErrorMessages>();
            foreach (var element in list)
            {
                Console.WriteLine(string.Format("Key: {0}; Value: {1}", element.Key, element.Value));
            }
            Console.Read();
            /* OUTPUT:
               Key: 1; Value: Error1
               Key: 2; Value: Error2
               Key: 3; Value: Error3 
               Key: 4; Value: Error4
            */
        }
        public class EnumValueDto
        {
            public int Key { get; set; }
            public string Value { get; set; }
            public static ICollection<EnumValueDto> ConvertEnumToList<T>() where T : struct, IConvertible
            {
                if (!typeof(T).IsEnum)
                {
                    throw new Exception("Type given T must be an Enum");
                }
                var result = Enum.GetValues(typeof(T))
                                 .Cast<T>()
                                 .Select(x => new EnumValueDto
                                 {
                                     Key = Convert.ToInt32(x),//values are arbitary here any datatype will work
                                     Value = x.ToString(new CultureInfo("en"))
                                 })
                                .Where(err => err.Key==3) //Instead of 3 as key here use Response variable instead
                                .ToList()
                                .AsReadOnly();
                return result;
            }
        }
        
    }
