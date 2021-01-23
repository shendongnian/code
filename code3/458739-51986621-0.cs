	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	namespace BinarySearchTree
	{
		
		public class Node
		{
			public Node(int iData)
			{
				data = iData;
				leftNode = null;
				rightNode= null;
			}
			public int data{get; set;}
			public Node leftNode{get; set;}
			public Node rightNode{get; set;}
		};
		public class Program
		{
			public static Node root = null;
			public static void Main(string[] args)
			{
				//Your code goes here
				Console.WriteLine("Hello, world!");
				root = new Node(20);
				InsertNode(root, new Node(10));
				InsertNode(root, new Node(15));
				InsertNode(root, new Node(13));
				InsertNode(root, new Node(11));
				InsertNode(root, new Node(12));
				InsertNode(root, new Node(25));
				InsertNode(root, new Node(22));
				InsertNode(root, new Node(23));
				InsertNode(root, new Node(27));
				InsertNode(root, new Node(26));
				
			   if(CheckIfTreeIsBalanced(root))
			   {
					Console.WriteLine("Tree is Balanced!");
			   }
			   else
			   {
				   Console.WriteLine("Tree is Not Balanced!");
			   }
				PrintTree(root);
			}
		   
			
			public static void PrintTree(Node root)
			{
			   if(root == null) return;        
			   Node temp = root;
			   
			   PrintTree(temp.leftNode);
			   System.Console.Write(temp.data + " "); 
			   PrintTree(temp.rightNode);
			}
			
			public static bool CheckIfTreeIsBalanced(Node root)
			{
				if(root != null)
				{
					if(root.leftNode != null && root.rightNode!= null)
					{
						if(root.leftNode.data < root.data && root.rightNode.data > root.data)
						{
							return CheckIfTreeIsBalanced(root.leftNode)&&CheckIfTreeIsBalanced(root.rightNode);
						}
						else
						{
							return false;
						}
					} 
					else if(root.leftNode != null)
					{
						if(root.leftNode.data < root.data)
						{
							return CheckIfTreeIsBalanced(root.leftNode);
						}
						else
						{
							return false;
						}
					}
					else if(root.rightNode != null)
					{
						if(root.rightNode.data > root.data)
						{
							return CheckIfTreeIsBalanced(root.rightNode);
						}
						else
						{
							return false;
						}
					}
				}
				 return true;
			}
			
			public static void InsertNode(Node root, Node newNode )
			{
			Node temp;
			temp = root;
			if (newNode.data < temp.data)
				{
					if (temp.leftNode == null)
					{
						temp.leftNode = newNode;
					}
					else
					{
						temp = temp.leftNode;
						InsertNode(temp,newNode);
					}
				}
				else if (newNode.data > temp.data)
				{
					if (temp.rightNode == null)
					{
						temp.rightNode = newNode;
					}
					else 
					{
						temp = temp.rightNode;
						InsertNode(temp,newNode);
					}
				}
			}
		}
	}
