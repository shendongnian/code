	using System;
	using System.IO;
	
	public class TreeBuilder
	{
		public TreeBuilder()
		{
			TreeNode rootNode = new TreeNode(@"\");
			rootNode.Name = @"\";
			
			RootNode = rootNode;
		}
		
		public TreeNode RootNode
		{
			get;
			set;
		}
		
		private void AddItemsToTree(string[] items)
		{
			Array.Sort(items);
			
			foreach (string item in items)
			{
				string[] itemParts = item.Split(new string[] {"@@"}, StringSplitOptions.None);
				string filePath = itemParts[0];
				string versionPath = itemParts[1];
				string fileParentPath = Path.GetDirectoryName(filePath);
				string versionParentPath = Path.GetDirectoryName(versionPath);
				
				TreeNode[] fileNodes = RootNode.Nodes.Find(filePath, true);
				TreeNode fileNode = null;
				
				if (fileNodes == null || fileNodes.Length == 0)
				{
					fileNode = new TreeNode(Path.GetFileName(filePath));
					fileNode.Name = filePath;
					
					TreeNode[] parentNodes = RootNode.Nodes.Find(fileParentPath, true);
	
					if (parentNodes != null && parentNodes.Length > 0)
					{
						parentNodes[0].Nodes.Add(fileNode);
					}
					else
					{
						RootNode.Nodes.Add(fileNode);
					}
				}
				else
				{
					fileNode = fileNodes[0];
				}
				
				TreeNode[] versionNodes = fileNode.Nodes.Find(item, true);
				TreeNode versionNode = null;
				
				if (versionNodes == null || versionNodes.Length == 0)
				{
					versionNode = new TreeNode(Path.GetFileName(versionPath));
					versionNode.Name = item;
					
					TreeNode[] parentNodes = fileNode.Nodes.Find(filePath + "@@" + versionParentPath, true);
	
					if (parentNodes != null && parentNodes.Length > 0)
					{
						parentNodes[0].Nodes.Add(versionNode);
					}
					else
					{
						RootNode.Nodes.Add(versionNode);
					}
				}
				else
				{
					versionNode = versionNodes[0];
				}				
			}
		}
	}
