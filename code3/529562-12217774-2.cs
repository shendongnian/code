    var csv =
        from line in File.ReadAllLines("C:/file.csv")
        let customerRecord = line.Split(',')
        select new Customer()
            {
                contactID = customerRecord[0],
                surveyDate = DateTime.Parse(customerRecord[1]),
                project = customerRecord[2],
                projectCode = customerRecord[3]
            };
    
    public class Customer
        {
            public string contactID { get; set; }
            public DateTime surveyDate { get; set; }
            public string project { get; set; }
            public string projectCode { get; set; }
        }
