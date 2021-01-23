    public class CheckDataViewModel 
        {
            public CheckDataViewModel ()
            {
                this.AvailableCeremony = new List<SelectListItem>();
                this.AvailableDegree = new List<SelectListItem>();
            }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string last_name { get; set; }
            public int student_id { get; set; }
            public int ceremony_id { get; set; }
            public DateTime ceremony_date { get; set; }
            public int graduand_id { get; set; }
            public IList<SelectListItem> AvailableCeremony { get; set; }
            public graduandDegreeModel graduandDegreeGroup { get; set; }
            public  string degree_id { get; set; }
            public  string degree_name { get; set; }
            public IList<SelectListItem> AvailableDegree { get; set; }
        }
