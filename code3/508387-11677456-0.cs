     using System;
     using System.Collections.Generic;
     namespace DoFactory.GangOfFour.Composite.Structural
    {
    /// <summary>
    /// MainApp startup class for Structural 
    /// Composite Design Pattern.  
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create a tree structure
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A")); //1st Add for root
            root.Add(new Leaf("Leaf B")); //2nd Add for root
            Console.WriteLine(" ....");
            root.Display(1);
            Console.WriteLine("...........");
            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            root.Add(comp); //add comp to root //3rd Add for root
            DerivedComposite myDerivedComposite = new DerivedComposite("derived member",      1000);
            Console.WriteLine("Show the special int, string for DerivedComposite");
            myDerivedComposite.mySpecialVariablesAre();
            Console.WriteLine("........");
            root.Add(myDerivedComposite); //4th Add for root
                  
            Composite SecondRoot = new Composite("SecondRoot");
            SecondRoot.Add(new Leaf("Leaf fA"));
            
            SecondRoot.Add(myDerivedComposite); //add to SecondRoot
            root.Add(SecondRoot); //add comp to root ; //5th Add for root
            //// Recursively display tree again, after adding
            root.Display(1);
            Console.WriteLine("Now get List read back");
            Console.WriteLine("show List elements for root (should be five)");
            root.DisplayList();
            Console.WriteLine("Show List elements for comp (should be one)");
            comp.DisplayList();
            Console.WriteLine("Show List ele for SecondRoot (should be 2)");
             SecondRoot.DisplayList();
            
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    abstract class Component
    {
        protected string name;
        // Constructor
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
        public abstract void printSpecialInt();
    }
    /// <summary>
    /// The 'Composite' class
    /// </summary>
    class Composite : Component
    {
        private List<Component> _children = new List<Component>(); 
        //This Generic List was potentially troublesome but it executed fine
        protected int specialbaseInt;
        // Constructor
        public Composite(string name)
            : base(name)
        {
            specialbaseInt = -1;
        }
        public override void Add(Component component)
        {
            _children.Add(component);
        }
        public override void Remove(Component component)
        {
            _children.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            // Recursively display child nodes
            foreach (Component component in _children)
            {
                component.Display(depth + 2); //calls .Display again, is recursive
            }
        }
        public void DisplayList()
        {
            int ijk = _children.Count;
            Console.WriteLine("# elements in this List: {0}", ijk);
            foreach (Component c in _children)
            {
                int ii = c.GetHashCode();
                Type type = c.GetType();
                Console.WriteLine("GetHashCode, Type on list: {0}, {1}", ii, type.FullName);
                c.printSpecialInt();
 
            }
        }
        public override void printSpecialInt()
        {
            Console.WriteLine("special int (at base class): {0}", specialbaseInt);
        }
    }
    class DerivedComposite : Composite
    {
        public string myExtraString;
        public int mySpecialInt;
        public DerivedComposite(string name,int ianint)
            : base(name)
        {
            myExtraString = name;
            mySpecialInt = ianint + 10;
            specialbaseInt = ianint;
        }
        public void mySpecialVariablesAre()
        {
            Console.WriteLine("The string, int, specialbaseInt are!- {0}, {1}, {2}", myExtraString, mySpecialInt, specialbaseInt);
        }
        public override void printSpecialInt()
        {
            Console.WriteLine("The string, int, specialbaseInt are (at derived): {0}, {1},    {2}", myExtraString, mySpecialInt, specialbaseInt);
        }
    }
    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    class Leaf : Component
    {
        // Constructor
        public Leaf(string name)
            : base(name)
        {
        }
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }
        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
        public override void printSpecialInt()
        {
            Console.WriteLine("at Leaf printSpecialInt");
        }
    }
    /// <summary>
    /// The 'Leafail' class //try and make it fail
    /// </summary>
    class Leafail : Component
    {
        // Constructor
        public Leafail(string name)
            : base(name)
        {
            myExtraString = "Hi, I am Leafail";
            mySpecialInt = 123;
        }
        public string myExtraString;
        public int mySpecialInt;
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leafail");
        }
        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leafail");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
        public void mySpecialVariablesAre()
        {
            Console.WriteLine("The string, int are: {0}, {1}", myExtraString,mySpecialInt);
        }
        public override void printSpecialInt()
         {
             Console.WriteLine("at Leafail printSpecialInt");
         }
    }
    }
     
