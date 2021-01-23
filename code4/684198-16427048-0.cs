    class Base
    {
        private readonly List<Tuple<string, Action>> steps = new List<Tuple<string, Action>>();
        protected void RegisterStep(string parameter, Action someLogic)
        {
            steps.Add(Tuple.Create(parameter, someLogic));
        }
        protected void Run()
        {
            foreach (var step in steps)
            {
                var result = RunStep(step.Item1);
                if (result == null)
                {
                    break;
                }
                // perform some logic
                step.Item2();
            }
        }
        private object RunStep(string parameter)
        {
            // some implementation
            return null;
        }
    }
    class Derived : Base
    {
        public Derived()
        {
            RegisterStep("1", () => { });
            RegisterStep("2", () => { });
            RegisterStep("3", () => { });
            
            // etc
        }
    }
