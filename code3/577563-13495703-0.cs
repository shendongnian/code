    public class CParam
    {
        ....
        public CParam(Expression<Func<ushort>> ex, string t_HumanDesc, ushort DefaultVal)
        {
            Content = DefaultVal;
            HumanDesc = t_HumanDesc;
            Description = ((MemberExpression) ex.Body).Member.Name;
            Register = ex.Compile().Invoke();
        }
    };
