        class ExpandableQueryAttribute : Attribute
        {
            private LambdaExpression someLambda;
            //ctor
            public ExpandableQueryAttribute(Type hostingType, string filterMethod)
            {
                someLambda = (LambdaExpression)hostingType.GetField(filterMethod).GetValue(null); 
                // could also use a static method
            }
        }
