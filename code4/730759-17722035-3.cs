      public static class PropertySupport
      {       
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
          if (propertyExpression == null)
          {
            throw new ArgumentNullException("propertyExpression");
          }
    
          var memberExpression = propertyExpression.Body as MemberExpression;
          if (memberExpression == null)
          {
            throw new ArgumentException("", "propertyExpression");
          }      
          return memberExpression.Member.Name;
        }
      }
      public class MyClass
      {
        public MyClass PropertyOne { get; set; }
      }
      class Program
      {    
        static void Main(string[] args)
        {      
          Console.WriteLine(PropertySupport.ExtractPropertyName(() => new MyClass().PropertyOne));
          Console.ReadKey();
        }   
      }
