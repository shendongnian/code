    class Node 
    {
        public Node Left { get; private set; }
        public Node Right { get; private set; }
        public string Value { get; private set; }
        public Node(string value) : this(null, null, value) {}
        public Node(Node left, Node right, string value)
        {
            this.Left = left;
            this.Right = right;
            this.Value = value;
        }
    }
    ...
    Node n1 = new Node("1");
    Node n2 = new Node("2");
    Node n3 = new Node("3");
    Node n3 = new Node("4");
    Node n3 = new Node("5");
    Node p1 = new Node(n1, n2, "+");
    Node p2 = new Node(p1, n3, "*");
    Node p3 = new Node(n4, n5, "+");
    Node p4 = new Node(p2, p3, "-");
