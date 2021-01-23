    public  static int FindMin(IEnumerable<int> numbers)
        {
            Expression<Func<int, int, int>> expression = (left, right) => left < right ? left : right;
            InvocationExpression invoker = Expression.Invoke(expression,
                                       Expression.Constant(numbers.First())
                                      , Expression.Constant(numbers.ToList()[1]));
            foreach (int number in numbers.Skip(2))
            {
                invoker = Expression.Invoke(expression,
                                   invoker,
                                   Expression.Constant(number));
            }
            var lambdaExpression = Expression.Lambda<Func<int>>(invoker);
            Console.WriteLine($"Expression call tree:{lambdaExpression.ToString()}");
            return lambdaExpression.Compile().Invoke();
        }
    }
