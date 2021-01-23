        public void DijkstraAlgorithm(List<Node> graph)
        {
            List<DA> _algorithmList = new List<DA>(); //track the node cost/positioning
            DA _nodeToExamine = new DA(); //this is the node we're currently looking at.
            bool flag = true; //for exting the while loop later
            foreach (var node in graph)
	        {
                _algorithmList.Add(new DA(node));
	        }
            foreach (var children in _algorithmList[0].Name.Neighbors) //just starting at the first node
            {
                for (int i = 0; i < _algorithmList.Count; i++)
                {
                    if (children.Name == _algorithmList[i].Name)
                    {
                        _algorithmList[i].Parent = _algorithmList[0].Name;
                        _algorithmList[i].Cost = children.Miles;
                        _algorithmList[0].Complete = true;
                        
                    }
                }
            }
            while (flag) //loop through the rest to organize
            {
                _algorithmList = _algorithmList.OrderBy(x => x.Cost).ToList(); //sort by shortest path
                for (int i = 0; i < _algorithmList.Count; i++) //loop through each looking for a node that isn't complete
                {
                    if (_algorithmList[i].Complete == false)
                    {
                        _nodeToExamine = _algorithmList[i];
                        break;
                    }
                    if (i == 13) //if the counter reaches 13 then we have completed all nodes and should bail out of the loop
                        flag = false;
                }
                if (_nodeToExamine.Name.Neighbors.Count == 0) //set any nodes that do not have children to be complete
                {
                    _nodeToExamine.Complete = true;
                }
                foreach (var children in _nodeToExamine.Name.Neighbors) //loop through the children/neighbors to see if there's one with a shorter path
                {
                    for (int i = 0; i < _algorithmList.Count; i++) 
                    {
                        if (children.Name == _algorithmList[i].Name)
                        {
                            if (_nodeToExamine.Cost + children.Miles < _algorithmList[i].Cost) //found a better path
                            {
                                _algorithmList[i].Parent = _nodeToExamine.Name;
                                _algorithmList[i].Cost = _nodeToExamine.Cost + children.Miles;
                            }
                        }
                    }
                    _nodeToExamine.Complete = true;
                }
            }
            PrintDijkstraAlgoirthm(_algorithmList);
        }
        public void PrintDijkstraAlgoirthm(List<DA> _finalList)
        {
            foreach (var item in _finalList)
            {
               if (item.Parent != null)
                    Console.WriteLine("{0} ---> {1}: {2}", item.Parent.Name, item.Name.Name, item.Cost);
            }
        }
