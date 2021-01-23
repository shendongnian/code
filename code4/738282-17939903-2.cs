    public class VehicleState
    {
        List<Action> actionList = new List<Action>();
        public int passengers { get; set; }
        public void CommitState()
        {
            foreach (var action in actionList)
            {
                action();
            }
        }
        public void Execute(Action action)
        {
            actionList.Add(action);
        }
    }
