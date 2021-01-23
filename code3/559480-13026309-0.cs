    List<Process> opened = new List<Process>();
    
    private void TakeOverAllScreens()
        {
            int i = 0;
            foreach (Screen s in Screen.AllScreens)
            {
    
                if (s != Screen.PrimaryScreen)
                {
                    i++;
                   opened.Add(Process.Start(Application.ExecutablePath, "Screen|" + s.Bounds.X + "|" + s.Bounds.Y + "|" + i));
                }
            }
        }
