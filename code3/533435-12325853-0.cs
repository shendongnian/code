    public class Task : IComparable<Task>
    {
        public Task(int priority, Action action, Func<bool> needsToRun, string name = "Basic Task")
        {
            Priority = priority;
            Name = name;
            Action = action;
            _needsToRun = needsToRun;
        }
        public string Name { get; set; }
        public int Priority { get; set; }
        private readonly Func<bool> _needsToRun;
        public bool NeedsToRun { get { return _needsToRun.Invoke(); } }
        /// <summary>
        /// Gets or sets the action this task performs.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Action Action { get; set; }
        public void Run()
        {
            if (Action != null)
                Action.Invoke();
        }
        #region Implementation of IComparable<in State>
        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Task other)
        {
            return Priority == other.Priority && Name == other.Name ? 1 : 0;
        }
        #endregion
    }
