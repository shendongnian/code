    public class Student
    {
        [UseInOrderBy]
        public int Age { get; set; }
        [UseInOrderBy(Order = 1)]
        public string Name { get; set; } 
    }
    [AttributeUsage(AttributeTargets.Property)]
    internal class UseInOrderByAttribute : Attribute
    {
        public int Order { get; set; }
    }
