        public void TriggerEvent(string handler, EventArgs e)
        {
            MulticastDelegate eventDelegate =
                  (MulticastDelegate)this.GetType().GetField(handler,
                   System.Reflection.BindingFlags.Instance |
                   System.Reflection.BindingFlags.NonPublic).GetValue(this);
            Delegate[] delegates = eventDelegate.GetInvocationList();
            foreach (Delegate dlg in delegates)
            {
                dlg.Method.Invoke(dlg.Target, new object[] { this, e });
            } 
        }
