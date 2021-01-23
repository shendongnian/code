    public class Student
    {
        [UseInOrderBy]
        public int Age { get; set; }
        [UseInOrderBy(Order = 1)]
        public string Name { get; set; } 
    }
