    public void AddPath(string path)
    {
       char[] charSeparators = new char[] {'\\'};
       
       // Parse into a sequence of parts.
       string[] parts = path.Split(charSeparators, 
           StringSplitOptions.RemoveEmptyEntries);
       // The current node.  Start with this.
       Node current = this;
       // Iterate through the parts.
       foreach (string part in parts)
       {
           // The child node.
           Node child;
           // Does the part exist in the current node?  If
           // not, then add.
           if (!current._nodes.TryGetValue(part, out child))
           {
               // Add the child.
               child = new Node {
                   Path = part
               };
               // Add to the dictionary.
               current._nodes[part] = child;
           }
           // Set the current to the child.
           current = child;
       }
