    public static IEnumerable<Control> GetAllControls(Control control)
    {
        Stack<Control> stack = new Stack<Control>();
        stack.Push(control);
        while (stack.Any())
        {
            var next = stack.Pop();
            yield return next;
            foreach (Control child in next.Controls)
            {
                stack.Push(child);
            }
        }
    }
