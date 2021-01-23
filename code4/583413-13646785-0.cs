    public class Customer {
        public Category Category { get; set; }
    }
    public abstract class Category {
        public abstract void DoSomething();
    }
    public class CategoryA : Category {
        public override void DoSomething()
        {
            Console.WriteLine("A");
        }
    }
    public class CategoryB : Category {
        public override void DoSomething()
        {
            Console.WriteLine("B");
        }
    }
