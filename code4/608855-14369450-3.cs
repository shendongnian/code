    public State State
    {
       get { return this.EndDate.HasValue ? MyState.Completed : this._state; }
       set { this._state = value; }
    }
