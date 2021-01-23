    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthdate { get; set; }
        public string BirthDateStr
        {
            get
            {
                if (Birthdate != DateTime.MinValue)
                    return Birthdate.ToString();
                else
                    return "";
            }
    }
