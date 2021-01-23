    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main(String[] args)
            {
                var filePaths = new List<string> {@"ProgramDir\InstallDir\Module1\mod1pack1.exe", @"ProgramDir\InstallDir\Module1\mod1pack2.exe", @"ProgramDir\InstallDir\Module2\mod2pack1.exe", @"ProgramDir\InstallDir\Module1\SubModule1\report1.rpt", @"SystemDir\DependencyDir\dependency1.dll", @"SystemDir\DependencyDir\dependency2.dll"};
                var nodes = Parse(filePaths.ToArray());
                foreach (var node in nodes)
                    Console.Out.WriteLine(node.ToString());
                Console.ReadLine();
            }
    
            public static IEnumerable<Node> Parse(params String[] paths)
            {
                var roots = new NodeSet();
                foreach (var path in paths)
                {
                    var pathSplit = path.Split('\\');
                    Node current = null;
                    foreach (var pathElement in pathSplit)
                    {
                        var currentRoots = (current == null) ? roots : current.Children;
                        if (currentRoots.Contains(pathElement))
                            current = currentRoots[pathElement];
                        else
                            currentRoots.Add(current = new Node(pathElement));
                    }
                }
                return roots;
            }
    
            public class Node
            {
                public String Name { get; private set; }
                public NodeSet Children { get; private set; }
    
                public Node(String name)
                {
                    if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
                    Name = name;
                    Children = new NodeSet();
                }
    
                public override string ToString() { return ToString(1); }
    
                private String ToString(Int32 indent)
                {
                    var indentStr = Environment.NewLine + new string('\t', indent);
                    return Name + (Children.Count == 0 ? "" : indentStr + String.Join(indentStr, Children.Select(c => c.ToString(indent + 1)).ToArray()));
                }
            }
    
            public class NodeSet : KeyedCollection<String, Node> {
                protected override string GetKeyForItem(Node item) { return item.Name; }
            }
        }
    }
