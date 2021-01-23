    public class Result{
        public string ID { get;set; }
        public string Fac_Name { get; set; }
    }
    //Then do
    .Select(x => new Result { ID = x.Fac_Name.Substring(0, 6), Fac_Name = x.Fac_Name.Substring(0, 3) }
