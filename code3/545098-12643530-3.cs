    namespace Common
    {
        public class Mystery
        {
        }
    }
    namespace Fungi
    {
        public class Mushroom
        {
        }
    }
    namespace Vegetables
    {
        using Common;
        public Class Carrot
        {
            var strange = new Strange() // Compiles correctly.
            var mystery = new Mystery() // Compiles correctly.
            var orange = new Orange() // Won't compile, what's an Orange?
            var orange = new Fruit.Orange() // Compiles correctly.
            var mushroom = new Mushroom() // Won't compile, what's a Mushroom?
            var mushroom = new Fungi.Mushroom() // Compiles correctly.
        }
    }
