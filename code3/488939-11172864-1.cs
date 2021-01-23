    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
    	public class Program
    	{
    		private static readonly IndentedList indentedList = new IndentedList();
    
    		static void Main()
    		{
    			Fill();
    			indentedList.Items.ForEach(Print);
    		}
    
    		private static void Fill()
    		{
    			indentedList.Add(new Node()); // 1
    			indentedList.Add(new Node()); // 2
    			indentedList.Add(new Node()); // 3
    
    			indentedList.Items[0].Add(new Node()); // 1-1
    			indentedList.Items[0].Add(new Node()); // 1-2
    			indentedList.Items[0].Add(new Node()); // 1-3
    
    			indentedList.Items[1].Add(new Node()); // 2-1
    			indentedList.Items[1].Children[0].Add(new Node()); // 2-1-1
    		}
    
    		private static void Print(Node node)
    		{
    			var indentation = new String('\t', node.IndentationLevel - 1);
    			Console.WriteLine("{0}({1}) {2}", indentation, node.IndentationLevel, node);
    			node.Children.ForEach(Print);
    		}
    	}
    
    	public class IndentedList
    	{
    		private readonly Node superNode = new Node();
    
    		public List<Node> Items { get { return superNode.Children; } }
    
    		public void Add(Node node)
    		{
    			superNode.Add(node);
    		}
    	}
    
    	public class Node
    	{
    		public int IndentationLevel { get { return parent == null ? 0 : parent.IndentationLevel + 1; } }
    		public int Position { get { return parent.Children.IndexOf(this) + 1; } }
    		public List<Node> Children { get; private set; }
    
    		private Node parent;
    		private bool IsRootNode { get { return parent.parent == null; } }
    
    		public Node()
    		{
    			Children = new List<Node>();
    		}
    
    		public void Add(Node child)
    		{
    			child.parent = this;
    			Children.Add(child);
    		}
    
    		public override string ToString()
    		{
    			return IsRootNode ? Position.ToString() : String.Format("{0}-{1}", parent, Position);
    		}
    	}
    }
