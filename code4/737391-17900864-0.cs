    public class MyClass {
        // This method, the 'Finalizer' will be called when the class is destroyed.
        // The 'finalizer' is essentially just the name of the class with a '~' in front.
        ~MyClass() {
            Console.WriteLine("Destroyed!");
        }
    }
    public class Program {
        public static void Main() {
            MyClass referenceHeld = new MyClass(); // Reference held
            new MyClass(); // No reference held on this class
            WeakReference sameAsNoReference = new WeakReference(new MyClass()); // Equivalent to no reference.
            System.GC.Collect(); // Force the garbage collector to collect
            Console.ReadLine();
        }
    }
