    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public char Gender { get; set; }
        public SSN Social { get; private set; }
    }
    public class SSN
    {
        public const int SSN_LENGTH = 9;
    
        public string FirstThree { get; set; }
        public string MiddleTwo { get; set; }
        public string LastFour { get; set; }
    
        public SSN(string ssn)
        {
            FirstThree = ssn.Substring(0, 3); 
            MiddleTwo = ssn.Substring(2, 2);
            LastFour = ssn.Substring(5, 4);
        }
    
        public string ToString(bool format = false)
        {
            string formatDelimiter = "";
            if (format)
            {
                formatDelimiter = "-";
            }
    
            return FirstThree + formatDelimiter + MiddleTwo + formatDelimiter + LastFour;
        }
    }
