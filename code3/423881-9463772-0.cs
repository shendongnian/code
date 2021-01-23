                //event handler for menuItem Click
		private void mnuDelNode_Click(object sender,EventArgs e)
		{
			//better confirm before delete using a message box 
			
			DeleteRecursive(listView.SelectedNode);
		}
		private void DeleteRecursive(TreeNode root)
		{
			//your delete logic here
		}
