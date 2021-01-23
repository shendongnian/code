    private delegate void setServersCountDelegate(int idx, int cnt);
    private delegate void setChldNodeImgIndexDelegate(TreeNode tNode, int imgIdx);
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    	testBuildTree();
    }
    
    private void testBuildTree()
    {
    	Thread.CurrentThread.Name = "CheckServers";
    	Debug.WriteLine(String.Format("|||||||||| This is {0} thread", Thread.CurrentThread.ManagedThreadId));
    	changeImgIndex();
    }
    
    private void changeImgIndex()
    {
    	Debug.WriteLine(String.Format("--------- This is {0} thread", Thread.CurrentThread.ManagedThreadId));
    	TreeNodeCollection rootNodes = treeViewSrv.Nodes;
    	TreeNodeCollection childNodes;
    
    	for (int i = 0; i < rootNodes.Count; i++)
    	{
    		childNodes = treeViewSrv.Nodes[i].Nodes;
    		//treeViewSrv.Nodes[i].Text += string.Format(" ({0})", childNodes.Count);
    		treeViewSrv.Invoke(new setServersCountDelegate(setServersCount), new object[] { i, childNodes.Count });
    		int downServers = 0;
    		foreach (TreeNode tNode in childNodes)
    		{
    			if (tNode.Tag != null)
    			{
    				Dictionary<string, string> dicParams = tNode.Tag as Dictionary<string, string>;
    
    				if (!getServerStatus(dicParams["host"], dicParams["ip"]))
    				{
    					Debug.WriteLine(String.Format("<<<<<<<< This is {0} thread", Thread.CurrentThread.ManagedThreadId));
    					//tNode.ImageIndex = 1;   //red
    					treeViewSrv.Invoke(new setChldNodeImgIndexDelegate(setChldNodeImgIndex), new object[] { tNode, 1 });    //red
    					//rootNodes[i].ImageIndex = 2;   //yellow
    					treeViewSrv.Invoke(new setChldNodeImgIndexDelegate(setChldNodeImgIndex), new object[] { rootNodes[i], 2 }); //yellow
    					downServers++;
    				}
    			}
    		}
    
    		if (downServers == childNodes.Count)
    		{
    			//rootNodes[i].ImageIndex = 4;   //fatal red
    			treeViewSrv.Invoke(new setChldNodeImgIndexDelegate(setChldNodeImgIndex), new object[] { rootNodes[i], 4 });
    		}
    	}
    }
    
    private void setServersCount(int idx, int cnt)
    {
    	string[] spltNodeText = treeViewSrv.Nodes[idx].Text.Split(' ');
    	treeViewSrv.Nodes[idx].Text = string.Format("{0} ({1})", spltNodeText[0], cnt);
    }
    
    private void setChldNodeImgIndex(TreeNode tNode, int imgIdx)
    {
    	tNode.ImageIndex = imgIdx;
    }
