    public class MultiKeyLookup<TParam, TResult>
    {
        public INode<TParam, TResult> CreateLeaf(TResult result)
        {
            return new Leaf<TParam, TResult>(result);
        }
        public INode<TParam, TResult> CreateNode(
            params Tuple<TParam, INode<TParam, TResult>>[] values)
        {
            return new Node<TParam, TResult>(values);
        }
        public INode<TParam, TResult> Root { get; set; }
        public TResult GetValue(TParam[] parameters)
        {
            return Root.GetValue(parameters, 0);
        }
        //definition of Leaf goes here
        //definition of Node goes here
    }
