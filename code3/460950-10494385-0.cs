    public class HqlElements : HqlExpression
    {
        public HqlElements(IASTFactory factory, HqlExpression dictionary)
            : base(HqlSqlWalker.ELEMENTS, "elements", factory, dictionary)
        {
        }
    }
