    public class RcFields
    {
        public int RcNumber { get; set; }
        public string RcName { get; set; } 
    }
    List<RcFields> locationDepts = (from u in users 
                                    select new RcFields 
                                    { 
                                       u.RcNumber, 
                                       u.RcName 
                                    })
                                    .Distinct()
                                    .ToList();
