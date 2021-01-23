        public bool ContainsLabel(string label)
        {
            if (this.ChildLabel.Equals(label))
            {
                return true;
            }
            else
            {
                foreach (var child in Children)
                {
                    return child.ContainsLabel(label);
                }
            }
            return false;
        }
