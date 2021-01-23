    public interface IExpression
    {
        bool Match(string value);
    }
    public class AndExpression : IExpression
    {
        private IEnumerable<IExpression> expressions;
        public AndExpression(IEnumerable<IExpression> expressions)
        {
            this.expressions = expressions;
        }
        public bool Match(string value)
        {
            return expressions.All(exp => exp.Match(value));
        }
    }
    public class OrExpression : IExpression
    {
        private IEnumerable<IExpression> expressions;
        public OrExpression(IEnumerable<IExpression> expressions)
        {
            this.expressions = expressions;
        }
        public bool Match(string value)
        {
            return expressions.Any(exp => exp.Match(value));
        }
    }
    public class ContainsExpression : IExpression
    {
        private string search;
        public ContainsExpression(string search)
        {
            this.search = search;
        }
        public bool Match(string value)
        {
            return value.Contains(search);
        }
    }
