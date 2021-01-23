    public class TreeTester
    {
      public static void Main(string[] args)
      {
        var list = new ListForTrees(
            new[] { new fruit_trees("tree10",10,10,10), new fruit_trees("tree2",2,2,2) });
        list.AddTree( new fruit_trees("tree3",3,3,3) );     // middle
        list.AddTree( new fruit_trees("tree1",1,1,1) );     // first
        list.AddTree( new fruit_trees("tree50",50,50,50) ); // last
        list.AddTree( new fruit_trees("tree5",5,5,5) );     // middle
        Console.Write(list);
      }
    }
