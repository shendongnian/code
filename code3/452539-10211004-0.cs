    namespace ClassLibrary1
    {
       public interface ITransform
       {
          dynamic InverseTransform(dynamic point);
       }
    }
    
    using ClassLibrary1;
    using Moq;
    namespace ConsoleApplication9
    {
       interface IPoint { }
       class Point : IPoint { }
    
       class Program
       {
          static void Main(string[] args)
          {
             var transform = new Mock<ITransform>();
             IPoint x = transform.Object.InverseTransform(new Point());
          }
       }
    }
