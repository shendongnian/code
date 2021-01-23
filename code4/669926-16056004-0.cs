        private bool feIter(TreeModel model, TreePath path, TreeIter iter)
        {
            if (Values.GetValue(iter, 1) == ObjectStore)
            {
                return true; // exit loop
            }
            return false; // continue in loop
        }
        
        public void Blah()
        {
            Values.Foreach(feIter);
        }
