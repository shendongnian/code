    public class Customer {
        public Category Category { get; set; }
    }
    public abstract class Category {
    }
    public class CategoryA : Category {
    }
    public class CategoryB : Category {
    }
    public class CategoryService {
        public void DoSomething(CategoryA c) {
            Console.WriteLine("A");
        }
        public void DoSomething(CategoryB c) {
            Console.WriteLine("B");
        }
    }
