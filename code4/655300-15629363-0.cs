      public String FirstName
        {
            get
            {
                string firstName = null;
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(1);
                string[] loginNameParts = userName.Split('\\');
                string loginNameWithoutDomain = loginNameParts[1];
         
    
                var names = loginNameWithoutDomain.Split('.');
                
                
                firstName = names[0];
               
                return firstName;
    
            }
        }
        public String LastName
        {
            get
            {
                string lastName = null;
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(1);
                string[] loginNameParts = userName.Split('\\');
                string loginNameWithoutDomain = loginNameParts[1];
    
    
                var names = loginNameWithoutDomain.Split('.');
                
                lastName = names[1];
                
    
                return lastName;
    
            }
        }
        public void SortClass()
        {
            SortNodes(treProduct.Nodes);
    
            string nameToFind = LastName.Trim().ToUpper() + "," + " " + FirstName.Trim().ToUpper();
            var node = treProduct.FindNodeByText(nameToFind);
            if (node != null)
            {
                node.Remove();
                treProduct.Nodes.Insert(0, node);
                treProduct.Nodes[0].Expanded = true;
            }
        }
    
      public void Sort(RadTreeNodeCollection collection)
        {
            RadTreeNode[] nodes = new RadTreeNode[collection.Count];
            collection.CopyTo(nodes, 0);
            Array.Sort(nodes, new NodeSorter());
            collection.Clear();
            collection.AddRange(nodes);
        }
        /// <summary>
        /// SortNodes is a recursive method enumarating and sorting all area
        /// </summary>
        /// <param name="collection"></param>
    
        private void SortNodes(RadTreeNodeCollection collection)
        {
            Sort(collection);
    
            foreach (RadTreeNode node in collection)
            {
                if (node.Nodes.Count > 0)
                {
                    SortNodes(node.Nodes);
                }
    
            }
        }
        /// <summary>
        /// TreeNodeCOmpare define the sorting criteria
        /// </summary>
        public class NodeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                RadTreeNode tx = (RadTreeNode)x;
                RadTreeNode ty = (RadTreeNode)y;
    
                //if (tx.Text.Length != ty.Text.Length)
    
                //    return tx.Text.Length - ty.Text.Length;
                return string.Compare(tx.Text, ty.Text);
    
    
            }
    
        }
