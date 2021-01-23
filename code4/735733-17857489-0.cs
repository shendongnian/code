    public class FWrapper<TChild, TResult>{
	
        private int childCount;
        private string name;
        private Func<TChild, TResult> function;
	
        public Func<TChild, TResult> Function { get { return function; } }
	
        public FWrapper(Func<TChild, TResult> Function, int ChildCount, string Name){
            this.childCount = ChildCount;
            this.name = Name;
            this.function = Function;
       }
    }
    public class Node<TChild, TResult>{
	
        private FWrapper<TChild, TResult> fw;
        private IEnumerable<TChild> children;
	
        public Node(FWrapper<TChild, TResult> FW, IEnumerable<TChild> Children){
            this.fw = FW;
            this.children = Children;
        }
	
        public IEnumerable<TResult> Evaluate(){
            var results = new List<TResult>();
            foreach(var c in children){
                results.Add(fw.Function(c));
            }
		
            return results;
        }
    }
