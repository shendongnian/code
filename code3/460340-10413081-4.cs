    public class MyModel
    {
        public Manpower Manpower { get; set; }
        public SelectList Categories { get; set; }
        public SelectList MaritalStatuses { get; set; }
        public SelectList Religions { get; set; }
        public SelectList Languages { get; set; }
       
        //here's your Load Method to populate it
        public MyModel Load()
        {
            //load your Manpower object here
            Categories = new SelectList(db.Categories
                .OrderBy(x => x.Name)
                .ToList(), "Id", "Name");
            Countries = new SelectList(db.Countries
                .OrderBy(x => x.Name)
                .ToList(), "Id", "Name");
            MaritalStatuses = new SelectList(db.MaritalStatus
                .OrderBy(x => x.Name)
                .ToList(), "Id", "Name");
            Religions = new SelectList(db.Religions
                .OrderBy(x => x.Name)
                .ToList(), "Id", "Name");
            Languages = .new SelectList(db.Languages
                .OrderBy(x => x.Name)
                .ToList(), "Id", "Name");
        }
    }
