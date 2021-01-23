    public class LstFooddtlResult
    {
        public List<int> food_photo { get; set; }
        public string food { get; set; }
        public string qty_uom { get; set; }
        public string unitcost { get; set; }
    }
    
    public class RootObject
    {
        public List<LstFooddtlResult> lstResult { get; set; }
    }
