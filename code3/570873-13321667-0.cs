        public class ElementList
    {
        public IList List { get; }
        public int Count { get; }
        public ElementList()
        {
           
        }
        public void Add(Node e)
        {
            if (e == null)
            {
                return;
            }
            this.List.Add(e);
        }
        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new Exception("Index out of bounds");
            }
            List.RemoveAt(index);			
        }
        public void Remove(Element e)
        {
            List.Remove(e);
        }
        public Element Item(int index)
        {
            return (Element)this.List[index];
        }
    }
