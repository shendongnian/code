    class Node<TParam, TResult> : INode<TParam, TResult>
    {
        //private Tuple<TParam, INode<TParam, TResult>>[] values;
        private Dictionary<TParam, INode<TParam, TResult>> lookup;
        public Node(params Tuple<TParam, INode<TParam, TResult>>[] values)
        {
            lookup = values.ToDictionary(pair => pair.Item1,
                pair => pair.Item2);
        }
        public TResult GetValue(TParam[] parameters, int depth)
        {
            return lookup[parameters[depth]].GetValue(parameters, depth + 1);
        }
    }
