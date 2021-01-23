    public static class FixPoint
    {
        // Reusable fixpoint operator
        public static Func<T, TResult> Fix<T, TResult>(Func<Func<T, TResult>, Func<T, TResult>> f)
        {
            return t => f(Fix<T, TResult>(f))(t);
        }
    }
    
    public class Element
    {
        public List<Element> element;
                
    
        public int CalculateMaxDepth()
        {
            return FixPoint.Fix<List<Element>, int>(
                // recursive lambda
                f =>
                listElement => listElement == null || listElement.Count == 0 
                    ? 0 
                    : 1 + listElement.Select(e => f(e.element)).Max())
                (this.element);
        }
    
        [Test]
        public  void myTest()
        {
            var elt = new Element() { element = new List<Element> { new Element() { element = new List<Element> { new Element() { element = new List<Element> { new Element() } } } } } };
            Assert.AreEqual(3, elt.CalculateMaxDepth());
        }
    }
