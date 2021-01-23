    class Program
    {
        static void Main(string[] args)
        {
            var tree = GetTree();
            Node node;
            var val = Find(tree, 21, 1, out node);
            Console.WriteLine("depth: {0}", val);
            Console.WriteLine("\t{0}, {1}", node.Min, node.Max);
            Console.ReadKey();
        }
        private static int Find(Node curNode, int value, int level, out Node foundNode)
        {
            foundNode = curNode;
            foreach (var child in curNode.Children)
            {
                if (child.Min <= value && child.Max >= value)
                    return Find(child, value, level + 1, out foundNode);
            }
            return level;
        }
        private static Node GetTree()
        {
            var a = new Node(20, 40);
            var b = new Node(21, 22);
            var c = new Node(23, 33);
            var d = new Node(24, 29);
            var e = new Node(25, 26);
            var f = new Node(27, 28);
            var g = new Node(30, 31);
            var h = new Node(32, 33);
            var i = new Node(34, 37);
            var j = new Node(35, 36);
            var k = new Node(38, 39);
            d.Add(e);
            d.Add(f);
            c.Add(d);
            c.Add(g);
            c.Add(h);
            i.Add(j);
            a.Add(b);
            a.Add(c);
            a.Add(i);
            a.Add(k);
            return a;
        }
    }
    private static Node GetTree()
    {
        var a = new Node(20, 40);
        var b = new Node(21, 22);
        var c = new Node(23, 33);
        var d = new Node(24, 29);
        var e = new Node(25, 26);
        var f = new Node(27, 28);
        var g = new Node(30, 31);
        var h = new Node(32, 33);
        var i = new Node(34, 37);
        var j = new Node(35, 36);
        var k = new Node(38, 39);
        d.Add(e);
        d.Add(f);
        c.Add(d);
        c.Add(g);
        c.Add(h);
        i.Add(j);
        a.Add(b);
        a.Add(c);
        a.Add(i);
        a.Add(k);
        return a;
    }
