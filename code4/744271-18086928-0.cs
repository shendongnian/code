    var allControls = new List<Control>();
    var currentControls = new Queue<Control>;
    currentControls.Enqueue(this.Page);
    
    while(true)
    {
        var c = currentControls.Dequeue();
        if (c == null) break;
        if (!allControls.Contains(c))
        {
            allControls.Add(c);
            if (c.Controls != null && c.Controls.Count > 0)
            {
                foreach(var e in c.Controls)
                {
                    currentControls.Enque(e);
                }
            }
        }
    }
