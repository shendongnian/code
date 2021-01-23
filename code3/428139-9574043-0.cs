    [Table("LaborMaster"), Schema="HR"]
    public partial class LaborMaster
    {        
        [Key, ForeignKey("DeptMaster"), Column(Order = 0)]
        public decimal LCompanyNum {get;set;}
        [Key, ForeignKey("DeptMaster"), Column(Order = 1)]
        public decimal LDivisionNum {get;set;}
        [Key, ForeignKey("DeptMaster"), Column(Order = 2)]
        public decimal LDeptNum {get;set;}
        [Key, Column(Order = 3)]
        public decimal LEmployeeNum {get; set;}
        public string  LLaborName {get;set;}
        public virtual DeptMaster DeptMaster{ get; set; }
    }
