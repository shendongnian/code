     static void DynamicWhereBuilder()
            {
                var datas = new Data[]
                {
                    new Data { OrderDate  = "07/04/1996"},
                    new Data { OrderDate  = "07/04/1990"},
                    new Data { OrderDate  = "07/04/2001"},
                    new Data { OrderDate  = "2012/04/07"}
                };
                IQueryable<Data> queryableData = datas.AsQueryable<Data>();
    
                var formatConstant = Expression.Constant("{0:MM/dd/yyyy}", typeof(string));
                var parameter = Expression.Parameter(typeof(Data), "dataArg");
                var property = Expression.Property(parameter, "OrderDate");
    
                var left = Expression.Call(property, typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(object) }), formatConstant, property);
                var right = Expression.Constant("07/04/2001", typeof(string));
    
                var equal = Expression.Equal(left, right);
    
                var whereCallExpression = Expression.Call(
                     typeof(Queryable),
                     "Where",
                     new Type[] { queryableData.ElementType },
                     queryableData.Expression,
                     Expression.Lambda<Func<Data, bool>>(equal, new ParameterExpression[] { parameter }));
    
                var results = queryableData.Provider.CreateQuery<Data>(whereCallExpression); // returns the object with OrderDate = "07/04/2001"
    
            }
