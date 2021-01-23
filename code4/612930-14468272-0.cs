    public static IEnumerable<Control> GetAllControls(Control control)
    {
        Stack<Control> stack = new Stack<Control>();
    
        while (stack.Any())
        {
            var next = stack.Pop();
            yield return next;
            foreach (var child in next.Controls.OfType<Control>())
            {
                stack.Push(child);
            }
        }
    }
