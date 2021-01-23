        private Dictionary<long, WorkbookState> _states = new Dictionary<long, WorkbookState>();
        public WorkbookState WorkbookState
        {
            get
            {
                long hash = Application.ActiveWorkbook.GetHashery();
                WorkbookState state;
                if (!_states.TryGetValue(hash, out state))
                {
                    state = new WorkbookState();
                    _states[hash] = state;
                }
                return state;
            }
        }
