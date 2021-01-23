    public void ConnectNodes()
    {
       for (int i = 0; i < levels.Count - 1; i++)
       {
        	ConnectNodes(i, i + 1);
        	if (i == 0)
        		ConnectRoot();
       }
    }
    private void ConnectNodes(int level1, int level2)
    {
        int level1_nNodes = levels[level1].nodes.Count;
        int level2_nNodes = levels[level2].nodes.Count;
        for (int i = 0; i < level1_nNodes; i++)
        {
        	var node1 = levels[level1].nodes[i];
        	for (int j = 0; j < level2_nNodes; j++)
        	{
        		var node2 = levels[level2].nodes[j];
        		foreach (var itemReq in node1.data.itemsRequired)
        		{
        			if (node2.data.itemsRequired.Contains(itemReq))
        			{
        				node1.nodes.Add(node2);
        				break;
        			}
        		}
        	}
         }
    }
