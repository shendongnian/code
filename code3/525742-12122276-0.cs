    using System;
    using System.Linq.Expressions;
    using NUnit.Framework;
    
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public static class ExpressionBuilder
    {
        public static Expression<Func<TClass, TProperty>> Build<TClass, TProperty>(string fieldName)
        {
            var param = Expression.Parameter(typeof(TClass));
            var field = Expression.PropertyOrField(param, fieldName);
            return Expression.Lambda<Func<TClass, TProperty>>(field, param);
        }
    }
    
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestExpressionBuilder()
        {
            var person = new Person { FirstName = "firstName", LastName = "lastName" };
            var expression = ExpressionBuilder.Build<Person, string>("FirstName");
    
            var firstName = expression.Compile()(person);
    
            Assert.That(firstName, Is.EqualTo(person.FirstName));
        }
    }
