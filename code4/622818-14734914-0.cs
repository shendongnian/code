    public class Shape
        {
        }
        public class Triangle : Shape
        {
        }
        public class Square : Shape
        {
        }
        //T generic parameter is covariant (out keyword)
        public interface IShapeHolder<out T> where T : Shape
        {
        }
        public class ShapeHolder<T>  : IShapeHolder<T> where T: Shape
        { 
        }
