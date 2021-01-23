     private void FillTreeView()
    {
    	// Load the images in an ImageList.
    	ImageList myImageList = new ImageList();
    	myImageList.Images.Add(Image.FromFile("1.gif"));
    	myImageList.Images.Add(Image.FromFile("2.gif"));
    	myImageList.Images.Add(Image.FromFile("3.gif"));
    	myImageList.Images.Add(Image.FromFile("4.gif"));
    	myImageList.Images.Add(Image.FromFile("5.gif"));
    	myImageList.Images.Add(Image.FromFile("6.gif"));
    	myImageList.Images.Add(Image.FromFile("7.gif"));
    	
    	// Assign the ImageList to the TreeView.
    	myTreeView.ImageList = myImageList;
    	
    	// Set the TreeView control's default image and selected image indexes.
    	myTreeView.ImageIndex = 0;
    	myTreeView.SelectedImageIndex = 1;
    
    	/* Set the index of image from the 
    	ImageList for selected and unselected tree nodes.*/ 
    	this.rootImageIndex = 2;
    	this.selectedCustomerImageIndex = 3;
    	this.unselectedCustomerImageIndex = 4;
    	this.selectedOrderImageIndex = 5;
    	this.unselectedOrderImageIndex = 6;
    	
    	// Create the root tree node.
    	TreeNode rootNode = new TreeNode("TheList");
    	rootNode.ImageIndex = rootImageIndex;
    	rootNode.SelectedImageIndex = rootImageIndex;
    
    	// Add a main root tree node.
    	myTreeView.Nodes.Add(rootNode);
    
    	// Add a root tree node for each Customer object in the ArrayList. 
    	foreach(Customer myCustomer in customerArray)
    	{
    		// Add a child tree node for each Order object. 
    		int countIndex=0;
    		TreeNode[] myTreeNodeArray = new TreeNode[myCustomer.CustomerOrders.Count];
    		foreach(Order myOrder in myCustomer.CustomerOrders)
    		{
    			// Add the Order tree node to the array.
    			myTreeNodeArray[countIndex] = new TreeNode(myOrder.OrderID,
    			  unselectedOrderImageIndex, selectedOrderImageIndex);
    			countIndex++;
    		}
    		// Add the Customer tree node.
    		TreeNode customerNode = new TreeNode(myCustomer.CustomerName,
    			unselectedCustomerImageIndex, selectedCustomerImageIndex, myTreeNodeArray);
    		myTreeView.Nodes[0].Nodes.Add(customerNode);
    	}
    }
