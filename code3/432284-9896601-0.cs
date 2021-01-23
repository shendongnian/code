    public class State : Enumeration<State>
    {
        public static State Alabama = new State(1, "AL", "Alabama");
        public static State Alaska = new State(2, "AK", "Alaska");
        // .. many more
        public static State Wyoming = new State(3, "WY", "Wyoming");
    
        public State(int value, string displayName, string description) : base(value, displayName)
        {
            Description = description;
        }
    
        public string Description { get; private set; }
    }
    
    public IEnumerable<SelectListItem> Creating_a_select_list(State selected)
    {
        return State.GetAll().Select(
            x => new SelectListItem
            {
                Selected = x == selected,
                Text = x.Description,
                Value = x.Value.ToString()
            });
    }
