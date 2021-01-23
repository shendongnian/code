    public class EmpDetail
    {
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
    }
    var result = db.Fetch<EmpDetail>(Query);
