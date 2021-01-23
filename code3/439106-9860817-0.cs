    /// <summary>
    /// Dictionary for holding the controls design time Click EventHandlers.
    /// </summary>
    private Dictionary<Control, EventHandler> _interceptedClickEventHandlers;
    /// <summary>
    /// Recursively moves through the child controls assigning events for scrolling and replacing Click events 
    /// with an interception EventHandler that prevents the Click event occuring if the Panel was scrolled.
    /// </summary>
    /// <param name="control">The control to handle the events for and whose children to recurse through.</param>
    private void RecursivelySubscribeChildEvents(Control control)
    {
        if (!(control is IPanelItem))
        {
            return;
        }
        // Subscribe the events for the scroll handling
        control.MouseDown += new MouseEventHandler(UIPanel_MouseDown);
        control.MouseMove += new MouseEventHandler(UIPanel_MouseMove);
        control.MouseUp += new MouseEventHandler(UIPanel_MouseUp);
        // Intercept the click event
        FieldInfo eventClickField = typeof(Control).GetField("Click", BindingFlags.NonPublic | BindingFlags.Instance);
        if (eventClickField != null)
        {
            if (_interceptedClickEventHandlers == null)
            {
                _interceptedClickEventHandlers = new Dictionary<Control, EventHandler>();
            }
            // Get the original event and store it against the control for actioning later
            EventHandler eventClick = (EventHandler)eventClickField.GetValue(control);
            _interceptedClickEventHandlers.Add(control, eventClick);
            // Unsubscribe the old event and assign the interception event
            control.Click -= (EventHandler)eventClick;
            control.Click += new EventHandler(UIPanel_ChildClick);
        }
        // Recurse the event subscription operation
        foreach (Control child in control.Controls)
        {
            RecursivelySubscribeChildEvents(child);
        }
    }
    private void UIPanel_ChildClick(object sender, EventArgs e)
    {
        EventHandler interceptedHandler = _interceptedClickEventHandlers[(Control)sender];
        if (interceptedHandler != null)
        {
            // Fire the originally subscribed event if the panel is not scrolling
            if (!_isScrolling)
            {
                interceptedHandler(sender, e);
            }
        }
    }
