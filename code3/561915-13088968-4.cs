        static void Main(string[] args)
        {
            Node parent = new Node();
            Bus<WasModified>.Subscribe(parent, (s,a)=> parent.Modified = true);
            Node child = new Node();
            Node gchild = new Node();
            parent.Children.Add(child);
            parent.Children.Add(gchild);
            gchild.Modified = true;
            Console.WriteLine(parent.Modified);
            Console.ReadLine();
        }
    
