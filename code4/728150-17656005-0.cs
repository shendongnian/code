    public class Teacher
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Profession { get; set; }
        public static IEnumerable<Teacher> YieldFromCSV(string nameData, string ageData, string professionData)
        {
            // you really want to include error checking here
            var names = nameData.Split('|');
            var ages = ageData.Split('|');
            var professions = professionData.Split('|');
            for (var i = 0; i < names.Length; i++)
            {
                yield return new Teacher
                    {
                        Name = names[i],
                        Age = ages.ElementAtOrDefault(i),
                        Profession = professions.ElementAtOrDefault(i) ?? professions.ElementAtOrDefault(0)
                    };
            }
        }
    }
