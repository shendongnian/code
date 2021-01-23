    public static void PrintNode(Node node, int indent)
    {
        if (indent > 0) // don't print out root directory (level 1). 
        {
            var ending = node.IsDirectory ? Path.DirectorySeparatorChar.ToString() : "*";
            Console.WriteLine("{0}{1}{2}", new string('\t', indent - 1), node.Name, ending);
        }
        node.Children.ForEach(n => PrintNode(n, indent + 1));
    }
    ProgramDir\
        InstallDir\
                Module1\
                        mod1pack1.exe*
                        mod1pack2.exe*
                        SubModule1\
                                report1.rpt*
                Module2\
                        mod2pack1.exe*
    SystemDir\
        DependencyDir\
                dependency1.dll*
                dependency2.dll*
