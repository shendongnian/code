    // another way to search for asp elements on page
  
     public static void GetAllControls<T>(this Control control, IList<T> list) where T : Control
            {
                foreach (Control c in control.Controls)
                {
                    if (c != null && c is T)
                        list.Add(c as T);
                    if (c.HasControls())
                        GetAllControls<T>(c, list);
                }
            }
