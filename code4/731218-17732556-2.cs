    public static string GetName(this Expression<Func<object>> expr)
    {
        if (expr.Body.NodeType == ExpressionType.MemberAccess)
            return ((MemberExpression) expr.Body).Member.Name;
    
        //most value type lambdas will need this because creating the Expression
        //from the lambda adds a conversion step.
        if (expr.Body.NodeType == ExpressionType.Convert
                && ((UnaryExpression)expr.Body).Operand.NodeType 
                    == ExpressionType.MemberAccess)
            return ((MemberExpression)((UnaryExpression)expr.Body).Operand)
                       .Member.Name;
    
        throw new ArgumentException(
            "Argument 'expr' must be of the form ()=>variableName.");
    }
    public static void InitializeNew(this object me, params Expression<Func<T>>[] exprs) 
        where T:new()
    {
        var myType = me.GetType();
        foreach(var expr in exprs)
        {
           var memberName = expr.GetName()
           var myMember = myType.GetMember(memberName,
                   BindingFlags.Instance|BindingFlags.Public
                       |BindingFlags.NonPublic|BindingFlags.FlattenHierarchy,
                   MemberTypes.Field|MemberTypes.Property);
           if(myMember == null) 
               throw new InvalidOperationException(
                   "Only property or field members are valid as expression parameters");
           //it'd be nice to put these under some umbrella of "DataMembers",
           //abstracting the GetValue/SetValue methods
           if(myMember.MemberType == MemberTypes.Field)
               ((FieldInfo)myMember).SetValue(me, new T());
           else
               ((PropertyInfo)myMember).SetValue(me, new T());
        }
    }
    //usage
    class MyClass
    {
        public List<double[][]> list1;
        public List<double[][]> list2;
        public MyOtherObject object1;
        public MyClass()
        {
           this.Initialize(()=>list1, ()=>list2);
           this.Initialize(()=>object1); //each call can only have parameters of one type
        }
    }
