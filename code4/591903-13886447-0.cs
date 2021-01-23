            //The variable name for the parameter expression must match in all others
            var parameter = Expression.Parameter(typeof(Customer),"c");
            Expression<Func<Customer,bool>> firstNameCheck = c => c.FirstName == FirstNameSearchString;            
            Expression<Func<Customer,bool>> lastNameCheck = c => c.LastName == LastNameSearchString;
            Expression<Func<Customer,bool>> numberCheck = c => c.Number.ToString() == NumberSearchString;
            //Default to a true expression
            Expression ongoingExpression = Expression.Constant(true);
            if (//Filter on first name)
            {
                ongoingExpression = Expression.AndAlso(ongoingExpression, Expression.Invoke(firstNameCheck, parameter));
            }
            
            if (//Filter on last name)
            {
                ongoingExpression = Expression.AndAlso(ongoingExpression, Expression.Invoke(lastNameCheck, parameter));
            }
            
            if (//Filter on number)
            {
                ongoingExpression = Expression.AndAlso(ongoingExpression, Expression.Invoke(numberCheck, parameter));
            }
            var lambda = Expression.Lambda<Func<Customer, bool>>(ongoingExpression, parameter);            
            query = query.Where(lambda.Compile());
