    private T FindToolStrip<T>(Control control) where T : System.Windows.Forms.Control
        {
            if (control == null)
            {
                return null;
            }
            else if (control is T)
            {
                return (T)control;
            }
            else
            {
                T result = null;
                foreach (Control embedded in control.Controls)
                {
                    if (result == null)
                    {
                        result = FindToolStrip<T>(embedded);
                    }
                }
                return result;
            }
        }
