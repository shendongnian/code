    public class SampleHandler : IElementHandler {
        //Generic list of elements
        public List<IElement> elements = new List<IElement>();
        //Add the supplied item to the list
        public void Add(IWritable w) {
            if (w is WritableElement) {
                elements.AddRange(((WritableElement)w).Elements());
            }
        }
    }
