    public class SummaryFilterInfo
    {
        public List<State> States { get; set; }
        public List<State> StateSelection { get; set; }
        public SummaryFilterInfo()
        {
            var stateList = new StateList();
            States = new List<State>();
            StateSelection = stateList.GetAllStates();
        }
    }
