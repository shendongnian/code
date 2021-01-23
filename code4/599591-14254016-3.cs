        protected override void RaisePostBackEvent(
            IPostBackEventHandler sourceControl, string eventArgument)
        {
            // Hook everything in Page.Controls
            Stack<Control> st = new Stack<Control>();
            st.Push(Page);
            while (st.Count > 0)
            {
                var control = st.Pop();
                eventHooks.HookAll(control);
                foreach (Control child in control.Controls)
                {
                    st.Push(child);
                }
            }
            // Raise events
            base.RaisePostBackEvent(sourceControl, eventArgument);
        }
        private EventHooks hooks = new EventHooks();
