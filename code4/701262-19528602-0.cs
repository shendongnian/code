    public abstract class Master<TDetail> where TDetail : Detail
    {
        public int Id { get; set; }
        public List<Detail> Details { get; private set; }
        public abstract void AddDetail(TDetail detail);
        public abstract List<TDetail> GetDetails();
    }
    public class Master_1 : Master<Detail_1> 
    {
        public override void AddDetail(Detail_1 detail) 
        {
            Details.Add(detail);
        }
        public override List<Detail_1> GetDetails()
        {
            return Details.Select(d => (Detail_1)d).ToList();
        }
    }
    public class Master_2 : Master<Detail_2_Or_3> 
    {
        public override void AddDetail(Detail_2_Or_3 detail)
        {
            Details.Add(detail);
        }
        public override List<Detail_2_Or_3> GetDetails()
        {
            return Details.Select(d => (Detail_2_Or_3)d).ToList();
        }
    }
    public abstract class Detail
    {
        public int Id { get; set; }
        //Foriegn Key
        public int MasterId { get; private set;}
    }
    public class Detail_1 : Detail { }
    public abstract class Detail_2_Or_3 : Detail { }
    public class Detail_2 : Detail_2_Or_3 { }
    public class Detail_3 : Detail_2_Or_3 { }  
