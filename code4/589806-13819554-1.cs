    // Rubbish implementation
    public class ConcreteModifiableDAG : IModifiableDAG
    {
        private int nodeCount;
        private Dictionary<int, Dictionary<int, bool>> connections;
        public void SetNodeCount(int nodeCount) {
            this.nodeCount = nodeCount;
        }
        public void SetConnected(int from, int to, bool connected) {
            connections[from][to] = connected;
        }
        public int GetNodeCount() {
            return nodeCount;
        }
        public bool GetConnected(int from, int to) {
            return connections[from][to];
        }
    }
    // Create graph
    IModifiableDAG mdag = new ConcreteModifiableDAG();
    mdag.SetNodeCount(5);
    mdag.SetConnected(1, 5, true);
    // Pass fixed graph
    IDirectedAcyclicGraph dag = (IDirectedAcyclicGraph)mdag;
    dag.SetNodeCount(5);          // Doesn't exist
    dag.SetConnected(1, 5, true); // Doesn't exist
