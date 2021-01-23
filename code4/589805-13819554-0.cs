    public interface IDirectedAcyclicGraph
    {
        int GetNodeCount();
        bool GetConnected(int from, int to);
    }
    public interface IModifiableDAG : IDirectedAcyclicGraph
    {
        void SetNodeCount(int nodeCount);
        void SetConnected(int from, int to, bool connected);
    }
