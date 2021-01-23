    public class Customer
    {
        public string contactID { get; set; }
        public DateTime surveyDate { get; set; }
        public string project { get; set; }
        public string projectCode { get; set; }
        public static Customer Parse(string line)
        {
           var parts = line.Split(',');
           return new Customer{
             contactID = parts[0],
             surveyDate = DateTime.Parse(customerRecord[1]),
             project = customerRecord[2],
             projectCode = customerRecord[3]
          };
    };
