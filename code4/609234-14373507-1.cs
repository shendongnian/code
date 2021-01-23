    public IEnumerable<T> EnumerateRecursive<T>(Control root) 
    {
        Stack<Control> st = new Stack<Control>();
        st.Push(root);
        while (st.Count > 0)
        {
            var control = st.Pop();
            if (control is T)
            {
                yield return (T)control;
            }
            foreach (Control child in control.Controls)
            {
                st.Push(child);
            }
        }
    }
    public void Cleanup() 
    {
        foreach (Button bot in EnumerateRecursive<Button>(this.mainTable))
        {
            bot.BackColor = Color.White;
            bot.Enabled = false;
        }
    }
