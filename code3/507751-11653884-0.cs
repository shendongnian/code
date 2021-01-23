    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    
        public string displayNode()
        {
            StringBuilder output = new StringBuilder();
            displayNode(output, 0);
            return output.ToString();
        }
    
        private void displayNode(StringBuilder output, int depth)
        {
    
            if (Right != null)
                Right.displayNode(output, depth+1);
    
            output.Append('\t', depth);
            output.AppendLine(Data.ToString());
    
    
            if (Left != null)
                Left.displayNode(output, depth+1);
    
        }
    }
