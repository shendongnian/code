    public class MyDateTimePicker : DateTimePicker
    {
        /// <summary>
        /// Occurs when the property Value is changed programmatically.
        /// </summary>
        public event EventHandler<EventArgs> ValueChangedProgrammatically;
        /// <summary>
        /// Gets or sets a boolean that indicates if the calendar popup is open.
        /// </summary>
        public bool IsOpen { get; private set; }
        /// <summary>
        /// Raises the ValueChangedProgrammatically event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnValueChangedProgrammatically(EventArgs e)
        {
            ValueChangedProgrammatically?.Invoke(this, e);
        }
        /// <summary>
        /// Raises the DropDown event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            IsOpen = true;
        }
        protected override void OnCloseUp(EventArgs e)
        {
            base.OnCloseUp(e);
            IsOpen = false;
        }
        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            if (!Focused && !IsOpen)
            {
                /* If the control has no focus and the calendar is not opened, the value is most likely changed programmatically. */
                OnValueChangedProgrammatically(e);
            }
        }
    }
