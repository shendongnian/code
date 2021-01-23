            foreach (Control comp in panel1.Controls)
            {
                if (comp.Right >= panel1.Width || comp.Bottom >= panel1.Height)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
