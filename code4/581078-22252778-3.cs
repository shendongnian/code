    public interface IStatement
    {
        [UnregisteredCustomer]
        string PolicyNumber { get; set; }
        string PlanCode { get; set; }
        PlanStatus PlanStatus { get; set; }
        [UnregisteredCustomer]
        decimal TotalAmount { get; }
        [UnregisteredCustomer]
        ICollection<IBalance> Balances { get; }
        void SetBalances(IBalance[] balances);
    }
