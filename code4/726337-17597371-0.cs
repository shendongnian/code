    Expression<Func<Car, bool>> theCarIsRed = c1 => c1.Color == "Red";
    Expression<Func<Car, bool>> theCarIsCheap = c2 => c2.Price < 10.0;
    Expression<Func<Car, bool>> theCarIsRedOrCheap = Expression.Lambda<Func<Car, bool>>(
        Expression.Or(theCarIsRed.Body, theCarIsCheap.Body), theCarIsRed.Parameters.Single());
    var query = carQuery.Where(theCarIsRedOrCheap);
