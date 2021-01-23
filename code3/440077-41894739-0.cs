    public class UnpaidChequeMap : SubclassMap<UnpaidCheque>
    {
        public UnpaidChequeMap()
        {
            Schema("Account");
            DiscriminatorValue("U");
            Join("UnpaidCheque", j =>
            {
                j.KeyColumn("OperationId");
                j.Map(_ => _.UnpaidOn).Column("UnpaidOn").Not.Nullable();
                j.Map(_ => _.UnpaidByUserId).Column("UnpaidByUserId").Not.Nullable();
            }
        }
    }
