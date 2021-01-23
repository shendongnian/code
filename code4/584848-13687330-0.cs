    public class Node
    {
        public string Name { get; set; }
        public Node Next { get; set; }
        
        public void InsertAt(string name, int index, Node start)
        {
            Node current = start;
            // Skip nodes until you reach the position
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            // Save next node
            Node next = current.Next;
            // Link
            current.Next = new Node () { Name = name, Next = next };
        }
    }
