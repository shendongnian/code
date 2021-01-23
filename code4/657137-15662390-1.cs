        private static INodeCollection NodesLookUp(string path, Int32 currentLevel, Int32 maxLevel)
        {
            if (currentLevel > maxLevel)
            {
                return null;
            }
            var shareCollectionNode = new ShareCollection(path);
            // Do somethings
            foreach (var directory in Directory.GetDirectories(shareCollectionNode.FullPath))
            {
                INodeCollection foundCollection = NodesLookUp(directory, currentLevel + 1, maxLevel)
                if(foundCollection != null)
                {                
                    shareCollectionNode.AddNode();
                }
            }
            return shareCollectionNode;
        }
