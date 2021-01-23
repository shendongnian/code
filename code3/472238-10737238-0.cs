    public class Person
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lastname { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Firstname { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Middlename { get; set; }
    }
