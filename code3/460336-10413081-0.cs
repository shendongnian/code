    public class MyModel
    {
        public Manpower Manpower { get; set; }
        public Dictionary<string, string> Categories { get; set; }
        public Dictionary<string, string> MaritalStatuses { get; set; }
        public Dictionary<string, string> Religions { get; set; }
        public Dictionary<string, string> Languages { get; set; }
       
        //here's your Load Method to populate it
        public MyModel Load()
        {
            //load your Manpower object here
            Categories = db.Categories
                .OrderBy(x => x.Name)
                .ToDictionary(x => x.Id.ToString(), x => x.Name)
            Countries = db.Countries
                .OrderBy(x => x.Name)
                .ToDictionary(x => x.Id.ToString(), x => x.Name)
            MaritalStatuses = db.MaritalStatus
                .OrderBy(x => x.Name)
                .ToDictionary(x => x.Id.ToString(), x => x.Name)
            Religions = db.Religions
                .OrderBy(x => x.Name)
                .ToDictionary(x => x.Id.ToString(), x => x.Name) 
            Languages = db.Languages
                .OrderBy(x => x.Name)
                .ToDictionary(x => x.Id.ToString(), x => x.Name)
        }
    }
