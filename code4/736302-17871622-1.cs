	public static partial class TestClass {
		public static void TestMethod() {
			DataStructure<char, AdvancedNode<char>> d=
				new DataStructure<char, AdvancedNode<char>>();
			d.RootNode=new AdvancedNode<char>();
			d.RootNode.NextNode=new AdvancedNode<char>();
			// type NO error! Will compile
			AdvancedNode<char> y=d.RootNode.NextNode;
			var rootNode=d.RootNode;
			var lastNode=rootNode.GetLastNode();
			Console.WriteLine("Is y the last node? "+(lastNode==y));
			Console.WriteLine("Is rootNode the last node? "+(lastNode==rootNode));
		}
	}
