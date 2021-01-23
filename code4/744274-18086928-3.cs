    public class UIControlsHelper
    {
        public static void ClearTextboxes(Page page)
        {
            var allControls = new List<Control>();
            var currentControls = new Queue<Control>();
            currentControls.Enqueue(page);
    
            while (currentControls.Count >0)
            {
                var c = currentControls.Dequeue();
                if (!allControls.Contains(c))
                {
                    allControls.Add(c);
    
                    var textbox = c as TextBox;
                    if (textbox != null) textbox.Text = string.Empty;
    
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
    }
