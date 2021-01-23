    abstract class Animal { }
    class Mammal : Animal { }
    class Dog : Mammal { }
    class Reptile : Animal { }
    interface INode<out T> where T : Animal
    {
        T MySelf { get; }
        IEnumerable<INode<T>> Children { get; }
    }
    class Node<T> : INode<T>
        where T : Animal
    {
        public Node() { this.Children = new HashSet<INode<T>>(); }
        public T MySelf { get; set; }
        public ISet<INode<T>> Children { get; set; }
        IEnumerable<INode<T>> INode<T>.Children { get { return this.Children; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // this is a 'typical' setup - to test compiler 'denial' for the Reptile type...
            Node<Mammal> tree = new Node<Mammal>();
            tree.MySelf = new Mammal();
            var node1 = new Node<Mammal>();
            tree.Children.Add(node1);
            var node2 = new Node<Dog>();
            tree.Children.Add(node2);
            var node3 = new Node<Reptile>();
            // tree.Children.Add(node3); // this fails to compile
            // ...and similar just more 'open' - if you 'collect' animals, all are welcome
            Node<Animal> animals = new Node<Animal>();
            animals.MySelf = new Mammal();
            INode<Mammal> mamals = new Node<Mammal>();
            animals.Children.Add(mamals);
            var dogs = new Node<Dog>();
            animals.Children.Add(dogs);
            INode<Animal> reptiles = new Node<Reptile>();
            animals.Children.Add(reptiles);
        }
    }
