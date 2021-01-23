    protected override Expression VisitConstant(ConstantExpression c)
    {
        if (c.Value != null && !IsNumeric(c.Value.GetType())) {
            NamedValueExpression nv;
            TypeAndValue tv = new TypeAndValue(c.Type, c.Value, iParam);
                
            string name = "p" + (iParam++);
            nv = new NamedValueExpression(name, this.language.TypeSystem.GetColumnType(c.Type), c);
            this.map.Add(tv, nv);
                
            return nv;
        }
        return c;
    }
