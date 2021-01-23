    class Visitor<T> : ExpressionVisitor
    {
        ParameterExpression _parameter;
        //there must be only one instance of parameter expression for each parameter 
        //there is one so one passed here
        public Visitor(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
        //this method replaces original parameter with given in constructor
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameter;
        }
        //this one is required because PersonData does not implement IPerson and it finds
        //property in PersonData with thesame name as the one referenced in expression 
        //and declared on IPerson
        protected override Expression VisitMember(MemberExpression node)
        {
            //only properties are allowed if you use fields then you need to extend
            // this method to handle them
            if (node.Member.MemberType != System.Reflection.MemberTypes.Property)
                throw new NotImplementedException();
            //name of a member referenced in original expression in your 
            //sample Id in mine Prop
            var memberName = node.Member.Name;
            //find property on type T (=PersonData) by name
            var otherMember = typeof(T).GetProperty(memberName);
            //visit left side of this expression p.Id this would be p
            var inner = Visit(node.Expression);
            return Expression.Property(inner, otherMember);
        }
    }
