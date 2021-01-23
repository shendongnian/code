c#
public class User : AggregateRoot
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    ...
}
and you have `GetById` method from the repository to reconstruct the *User*
c#
public class UserRepository : Repository<User>, IUserRepository
{
    private UserRepository(IDbConnection dbConnection) : base(dbConnection) {}
    ...
    public User GetById(int id)
    {
        const string sql = @"
            SELECT *
            FROM [User]
            WHERE ID = @userId;
        ";
        return base.DbConnection.QuerySingleOrDefault<User>(
            sql: sql,
            param: new { userId = id }
        );
    }
}
As long as the *sql* returns an **Id** and **Name** column, those will be automatically mapped to your *User* class matching properties, even when they have private setters. Nice and clean!
###The problem comes when you have relationships###
Everything becomes tricky when you have one-to-many objects you need to load up. 
Let's say now the *User* class has a read-only car list that belongs to the *User*, and some methods you can use to add/remove cars:
c#
public class User : AggregateRoot
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    private readonly IList<Car> _cars = new List<Car>();
    public IEnumerable<Car> Cars => _cars;
    public void PurchaseCar(Car car)
    {
        _cars.Add(car);
 
        AddEvent(new CarPurchasedByUser { ... });
    }
    public void SellCar(Car car)
    {
        _cars.Remove(car);
        AddEvent(new CarSoldByUser { ... });
    }
}
public class Car : Entity
{
    public int Id { get; private set; }
    public string Brand { get; private set; }
}
Now how do you load up the car list when *User* class is constructed? 
Some suggested to just run multiple queries and you construct the car list after you construct the user by calling the `PurchaseCar` and `SellCar` methods (or whatever methods available in the class) to add/remove cars:
c#
public User GetById(int id)
{
    const string sql = @"
        SELECT *
        FROM [User]
        WHERE ID = @userId;
        SELECT *
        FROM [Car]
        WHERE UserID = @userId;
    ";
    using (var multi = base.DbConnection.QueryMultiple(sql, new { userId = id })
    {
        var user = multi.Read<User>()
            .FirstOrDefault();
        if (user != null)
        {
            var cars = multi.Read<Car>();
            foreach (var car in cars)
            {
                user.PurchaseCar(car);
            }
        }
        return user;
    }
}
But you really **can't** do so if you're practicing `Domain-Driven Design` as those methods usually would have additional events they will fire that might be subscribed by others to fire up other commands. You were just trying to initialize your *User* object.
###Reflection!###
The only thing that worked for me is to use `System.Reflection`!
c#
public User GetById(int id)
{
    const string sql = @"
        SELECT *
        FROM [User]
        WHERE ID = @userId;
        SELECT *
        FROM [Car]
        WHERE UserID = @userId;
    ";
    using (var multi = base.DbConnection.QueryMultiple(sql, new { userId = id })
    {
        var user = multi.Read<User>()
            .FirstOrDefault();
        if (user != null)
        {
            var cars = multi.Read<Car>();
            // Load user car list using Reflection
            var privateCarListField = user.GetType()
                .GetField("_cars", BindingFlags.NonPublic | BindingFlags.Instance);
            privateCarListField.SetValue(car, cars);
        }
        return user;
    }
}
