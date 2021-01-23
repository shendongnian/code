    public class Buffer
    {
        private List<Node> _nodes;
        private List<double> numsA;
        void MyMethod()
        {
            List<double> numsA = new List<double>();
            List<double> numsB = new List<double>();
            foreach (Node node in _nodes)
            {
                numsA.Add(node.A);
                numsB.Add(node.B);
            }
            double sumA = numsA.Sum();
            double sumB = numsB.Sum();
        }
    }
    
    public static class MyExtensions
    {
        public static double Sum(this List<double> nodes)
        {
            double sum = 0;
            foreach (double node in nodes)
            {
                sum += node;
            }
            return sum;
        }
    } 
