    public class Manager
    {
        private List<baseClass> _workers;
    
        public void Initialize(ClassType type)
        {
            switch (type)
            {
                case child1:
                  _workers.Add(correctChild);
                  break;
                case child2:
                  _workers.Add(correctChild);
                  break;
            }
        }
    }
