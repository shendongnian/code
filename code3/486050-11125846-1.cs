        using System;
        using System.Collections.Generic;
        using System.Data.Entity;
        using System.Linq;
        using System.Linq.Expressions;
        using System.Reflection;
        using System.Text;
        using System.Threading.Tasks;
        namespace ConsoleApplication3
        {
            class MyEntity
            {
                public int Id { get; set; }
                public string Description { get; set; }
            }
            class MyContext : DbContext
            {
                public DbSet<MyEntity> EntitySet { get; set; }
            }
            class Program
            {
                private static void Seed()
                {
                    using (var ctx = new MyContext())
                    {
                        if (!ctx.EntitySet.Any())
                        {
                            ctx.EntitySet.Add(new MyEntity() { Description = "abc" });
                            ctx.EntitySet.Add(new MyEntity() { Description = "xyz" });
                            ctx.EntitySet.Add(new MyEntity() { Description = null });
                            ctx.EntitySet.Add(new MyEntity() { Description = "123" });
                            ctx.SaveChanges();
                        }
                    }
                }
                private static void PrintEntities(IEnumerable<MyEntity> entities)
                {
                    foreach (var e in entities)
                    {
                        Console.WriteLine("Id: {0}, Description: {1}", e.Id, e.Description);
                    }
                }
                static void Main(string[] args)
                {
                    List<int> list = new List<int>() { 1, 3 };
                    Seed();
                    using (var ctx = new MyContext())
                    {
                        PrintEntities(DynamicContains(ctx.EntitySet, e => e.Id, new[] { 1, 4 }));
                        PrintEntities(DynamicContains(ctx.EntitySet, e => e.Description, new[] { null, "xyz" }));
                    }
                }
                private static IQueryable<TEntity> DynamicContains<TEntity, TProperty>(IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> property, IEnumerable<TProperty> values)
                {
                    var memberExpression = property.Body as MemberExpression; 
                    if (memberExpression == null || !(memberExpression.Member is PropertyInfo)) 
                    { 
                        throw new ArgumentException("Property expression expected", "property"); 
                    }
                    // get the generic .Contains method
                    var containsMethod =
                        typeof(Enumerable)
                        .GetMethods()
                        .Single(m => m.Name == "Contains" && m.GetParameters().Length == 2);
                    // convert the generic .Contains method so that is matches the type of the property
                    containsMethod = containsMethod.MakeGenericMethod(typeof(TProperty));
                    // build e => Enumerable.Contains(values, e.Property)
                    var lambda = 
                        Expression.Lambda<Func<TEntity, bool>>(
                            Expression.Call(
                                containsMethod, Expression.Constant(values), property.Body), 
                                property.Parameters.Single());
                    // return query.Where(e => Enumerable.Contains(values, e.Property))
                    return query.Where(lambda);
                }
            }
        }
