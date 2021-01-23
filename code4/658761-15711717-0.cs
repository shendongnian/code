    class DepthVisitor : ExpressionVisitor
    {
        private readonly Queue<Tuple<Expression, int>> m_queue =
            new Queue<Tuple<Expression, int>>();
        private bool m_canRecurse;
        private int m_depth;
        public int MeasureDepth(Expression expression)
        {
            m_queue.Enqueue(Tuple.Create(expression, 1));
            int maxDepth = 0;
            while (m_queue.Count > 0)
            {
                var tuple = m_queue.Dequeue();
                m_depth = tuple.Item2;
                if (m_depth > maxDepth)
                    maxDepth = m_depth;
                m_canRecurse = true;
                Visit(tuple.Item1);
            }
            return maxDepth;
        }
        public override Expression Visit(Expression node)
        {
            if (m_canRecurse)
            {
                m_canRecurse = false;
                base.Visit(node);
            }
            else
                m_queue.Enqueue(Tuple.Create(node, m_depth + 1));
            return node;
        }
    }
