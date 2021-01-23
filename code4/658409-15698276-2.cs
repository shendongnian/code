    public class Tree<T> where T : ICategory
    {
        List<Node<T>> values;
        public Tree()
        {
            this.values = new List<Node<T>>();
        }
        public Node<T> FindNode(int id)
        {
            if (values.Exists(input => input.Value.Id == id))
            {
                return values.Find(input => input.Value.Id == id);
            }
            else { return null; }
        }
        public void AddNode(T value)
        {
            Node<T> parent = FindNode(value.ParentId);
            if (parent != null)
            {
                parent.AddChild(value);
            }
        }
    }
       
