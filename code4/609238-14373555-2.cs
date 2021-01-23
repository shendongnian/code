    public IEnumerable<Button> EnumerateRecursive(Control root)
    {
        // Hook everything in Page.Controls
        Stack<Control> st = new Stack<Control>();
        st.Push(root);
    
        while (st.Count > 0)
        {
            var control = st.Pop();
            if (control is Button)
            {
                yield return (Button)control;
            }
    
            foreach (Control child in control.Controls)
            {
                st.Push(child);
            }
        }
    }
    public void Cleanup()
    {
        foreach (Button bot in EnumerateRecursive(this.mainTable))
        {
            bot.BackColor = Color.White;
            bot.Enabled = false;
        }
    }
