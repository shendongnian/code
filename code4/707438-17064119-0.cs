     public class AnnualPeriod : EntityBase<long>
     {
    [Key]
    public virtual int AnnualPeriodTypeId { get; set; }
    public virtual AnnualPeriodType AnnualPeriodType { get; set; }
    public virtual string Code { get; set; }
    public virtual DateTime StartDate { get; set; }
    public virtual DateTime EndDate { get; set; }
    public virtual ICollection<Counter> Counters { get; set; }
     }
