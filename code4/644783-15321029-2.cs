        public static void CreateMenuTree(BoxNode boxNode, string indent)
        {
            foreach (Box box in boxNode.BoxChildren)
            {
                Console.WriteLine(indent + box.Name);
                if (box.BoxNode != null && box.BoxNode.BoxChildren != null && box.BoxNode.BoxChildren.Count > 0)
                {
                    CreateMenuTree(box.BoxNode, indent + indent);
                }
            }
        }  
