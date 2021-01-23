    using System;
    
    public abstract class Shape : IComparable<Shape>
    {
        public abstract double Area { get; }
    
        public int CompareTo(Shape other)
        {
            return Area.CompareTo(other.Area);
        }
    }
    
    public interface ISomethingCircleImplements {}
    
    public class Circle : Shape, ISomethingCircleImplements
    {
        private readonly double radius;
        
        public Circle(double radius)
        {
            this.radius = radius;
        }
        
        public override double Area { get { return radius * radius * Math.PI; } }
    }
    
    class Test
    {
        static void Foo<T>(IComparable<T> item1, T item2)
            where T : ISomethingCircleImplements
        {
            Console.WriteLine(item1.CompareTo(item2));
        }
        
        static void Main()
        {
            Circle c1 = new Circle(10);
            Circle c2 = new Circle(20);
            
            Foo<Circle>(c1, c2);
        }
    }
