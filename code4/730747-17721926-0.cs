    public interface IMyReusableInterface {
        string KPI { get; set; }
        string Status { get; set; }
        // etc...
    }
    public partial GTMD_Financials: IMyReusableInterface {
    }
