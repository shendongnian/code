        //the rootSubs argument is a string array containing all the subkeys of the root keys
        private void buildRegistryListTreeFromScratch(string[] rootSubs) {
            RegistryKey rootKey = Registry.CurrentUser;
            registryTreeTracker.Name = "Current User";
            for (int i = 0; i < rootSubs.Length; i++) {
                registryTreeTracker.Children.Add(new RegistryTreeNode(rootSubs[i]));
            }
            for (int i = 0; i < rootSubs.Length; i++) {
                RegistryKey selectedKey = rootKey.OpenSubKey(rootSubs[i]);
                if (selectedKey.SubKeyCount > 0) {
                    subKeyBelow(rootSubs[i]);
                }
            }
        }
        private void subKeyBelow(string path) {
            RegistryKey rootKey = Registry.CurrentUser;
            RegistryKey selectedKey = rootKey.OpenSubKey(path);
            
            
            for (int i = 0; i < registryTreeTracker.Children.Count; i++){
                if (registryTreeTracker.Children[i].Name == path) {
                    recursiveSubKeyBelow(registryTreeTracker.Children[i], path);
                }
            }
        }
        private void recursiveSubKeyBelow(RegistryTreeNode currentNode, string path) {
            RegistryKey rootKey = Registry.CurrentUser;
            RegistryKey selectedKey = rootKey.OpenSubKey(path);
            string originalPath = path;
            RegistryKey originalKey = rootKey.OpenSubKey(originalPath);
            for (int i = 0; i < selectedKey.SubKeyCount; i++){
            currentNode.Children.Add(new RegistryTreeNode(selectedKey.GetSubKeyNames()[i]));
            }
            for (int i = 0; i < originalKey.SubKeyCount; i++) {
                string deeperPath = originalPath + "\\" + originalKey.GetSubKeyNames()[i];
                try {
                    selectedKey = rootKey.OpenSubKey(deeperPath);
                    if (selectedKey.SubKeyCount > 0) {
                        recursiveSubKeyBelow(currentNode.Children[i], deeperPath);
                    }
                } catch(SecurityException) {
                    i++;
                }
            }
        }
