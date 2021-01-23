    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Moq;
    using Xunit;
    
    namespace MyExample
    {
        public class Tests
        {
            [Fact]
            public void Test()
            {
                Dictionary<Type, object> data = new Dictionary<Type, object>
                {
                    { typeof(IQueryable<Cycle>), new List<Cycle> { new Cycle { Name = "Test" } }.AsQueryable() },
                    { typeof(IQueryable<Rider>), new List<Rider> { new Rider { Name = "1"}, new Rider { Name = "2" } }.AsQueryable() }
                };
    
                var mock = new Mock<IDataContext>();
                var setup = mock.GetType().GetMethods().Single(d => d.Name == "Setup" && d.ContainsGenericParameters);
                var param = Expression.Parameter(typeof(IDataContext), "i");
                foreach (var property in typeof(IDataContext).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    // Build lambda
                    var ex = Expression.Lambda(Expression.MakeMemberAccess(param, property), param);
    
                    // Get generic version of the Setup method
                    var typedSetup = setup.MakeGenericMethod(property.PropertyType);
    
                    // Run the Setup method
                    var returnedSetup = typedSetup.Invoke(mock, new[] { ex });
    
                    // Get generic version of IReturns interface
                    var iReturns = typedSetup.ReturnType.GetInterfaces().Single(d => d.Name.StartsWith("IReturns`"));
    
                    // Get the generic Returns method
                    var returns = iReturns.GetMethod("Returns", new Type[] { property.PropertyType });
    
                    // Run the returns method passing in our data
                    returns.Invoke(returnedSetup, new[] { data[property.PropertyType] });
                }
    
                Assert.Equal(1, mock.Object.Cycles.Count());
            }
        }
    
        public class Cycle
        {
            public string Name { get; set; }
        }
    
        public class Rider
        {
            public string Name { get; set; }
        }
    
        public interface IDataContext
        {
            IQueryable<Cycle> Cycles { get; set; }
    
            IQueryable<Rider> Riders { get; set; }
        }
    }
