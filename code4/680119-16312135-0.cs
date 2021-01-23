    public class StrangePeople
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public static implicit operator People(StrangePeople strangePerson)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - strangePerson.BirthDate.Year;
            if (strangePerson.BirthDate > today.AddYears(-age))
            {
                age--;
            }
            return new People
                        {
                            Name = strangePerson.Name,
                            Age = (ushort) age
                        };
        }
