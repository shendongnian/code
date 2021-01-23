    public class MyVisitor : DbExpressionVisitor
    {
        // cast it to the visitor interface/base - that way you'd have access to all methods,
        // as Parameterizer has to have them publically exposed anyway, for this to work
        readonly DbExpressionVisitor _defaultVisitor;
        public MyVisitor()
        {
            _defaultVisitor = new Parameterizer();
        }
        public Expression VisitProjection(ProjectionExpression proj)
        {
            return _defaultVisitor.Visit(proj);
        }
        // ...same for all others, just...
        // ... 
        // implement your own for one 'route'
        protected Expression VisitConstant(ConstantExpression c)
        {
            if (c.Value != null && !IsNumeric(c.Value.GetType())) {
                NamedValueExpression nv;
                TypeAndValue tv = new TypeAndValue(c.Type, c.Value);
                if (!this.map.TryGetValue(tv, out nv)) { // re-use same name-value if same type & value
                    string name = "p" + (iParam++);
                    nv = new NamedValueExpression(name, this.language.TypeSystem.GetColumnType(c.Type), c);
                    this.map.Add(tv, nv);
                }
                return nv;
            }
            return c;
        }
    }
