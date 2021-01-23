     void addToParentNode(TreeNode childNodes) 
        { 
            if ((childNodes != null) && (childNodes.Tag != null))
            {
                DirectoryInfo getDir = null;
                try {
                   getDir = new DirectoryInfo(childNodes.Tag.ToString()); 
                }
                catch(SecurityException) {
                     childNodes.ToolTipText = "no access";
                }
                catch(PathTooLongException) {
                    childNodes.ToolTipText = "path more then 254 chars";
                }
                catch(ArgumentException)
                {
                   childNodes.ToolTipText = "huh?";
                }
                if (getDir!=null) && (!getDir.Exists) return;
                DirectoryInfo[] dirList = null;
                try {
                   dirList = getDir.GetDirectories(); 
                }
                catch(UnauthorizedException) {
                    childNodes.ToolTipText = "no access";
                }
                catch(SecurityException)
                {
                     childNodes.ToolTipText = "no access";
                } 
                if (dirList == null) return;
                foreach (DirectoryInfo dir in dirList) 
                { 
                    TreeNode parentNode = new TreeNode(); 
                    parentNode.Text = dir.Name; 
                    parentNode.Tag = dir.FullName; 
                    childNodes.Nodes.Add(parentNode); 
                } 
           }
        } 
