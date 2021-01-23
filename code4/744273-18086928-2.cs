    IEnumerable<Control> GetAllControls()
    {
        var allControls = new List<Control>();
        var currentControls = new Queue<Control>();
        currentControls.Enqueue(this.Page);
        while (currentControls.Count >0)
        {
            var c = currentControls.Dequeue();
            if (!allControls.Contains(c))
            {
                allControls.Add(c);
                if (c.Controls != null && c.Controls.Count > 0)
                {
                    foreach (Control e in c.Controls)
                    {
                        currentControls.Enqueue(e);
                    }
                }
            }
        }
        return allControls;
    }
