            Process[] _process = null;
            _process = Process.GetProcessesByName("bf3");
            foreach (Process proc in _process)
            {
                proc.Kill();
                MessageBox.Show(proc.ToString());
            }
