        public PropertyInfo GetPropertyFromExpression<T>(Expression<Func<T, object>> GetPropertyLambda)
        {
            //same body of above method without the return line.
            var Result = (PropertyInfo)Exp.Member;
            var Sub = Exp.Expression;
            while (Sub is MemberExpression)
            {
                Exp = (MemberExpression)Sub;
                Result = (PropertyInfo)Exp.Member;
                Sub = Exp.Expression;
            }
            return Result;
            //beware, this will return the last property in the expression.
            //when using GetValue and SetValue, the object needed will not be
            //the first object in the expression, but the one prior to the last.
            //To use those methods with the first object, you will need to keep
            //track of all properties in all member expressions above and do
            //some recursive Get/Set following the sequence of the expression.
        }
