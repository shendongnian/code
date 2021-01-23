    class Factory 
    {
        public ITask Build(string input)
        {
            switch(input) {
                case "A":
                    return (ITask)Activator.CreateInstance(typeof(TaskA));
                case "B":
                    return (ITask)Activator.CreateInstance(typeof(TaskB));
                default;
                    throw new Exception();
            }
        }
    }
