    public class SomeClass
    {
        Expression<Func<tbl, bool, bool>> _templateExpression =
           (tbl r, bool isDeleted) => r.ID_Master == 5 && r.Year == 2008 && r.Month == 12 && r.IsDeleted == isDeleted;
        public Expression<Func<tbl, bool>> Foo(bool IsDeleted)
        {
            return _templateExpression.AssignAndReduce(IsDeleted);
        }
    }
