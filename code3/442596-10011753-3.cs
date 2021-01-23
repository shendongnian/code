    public interface ICommonAddress 
    {
        int id { get; set; }
        Mode mode { get; set; }
        Creator creator { get; set; }
        long[] siteList { get; set; }
        ICommonAddress CreateAddress();
    }
