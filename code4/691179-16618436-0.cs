        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        static extern IntPtr FindExecutable(string lpFile, string lpDirectory, StringBuilder lpResult);
        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            string path = @"C:\Users\Mike\Documents\SomeFile.xyz";
            string EXE = GetAssociatedExecutable(path);
            if (!string.IsNullOrEmpty(EXE))
            {
                MessageBox.Show(EXE, "Associated Executable");
            }
            else
            {
                MessageBox.Show("No Asssociated Executable for: " + path);
            }
        }
        private string GetAssociatedExecutable(string filename)
        {
            const int MAX_PATH = 260;
            if (System.IO.File.Exists(filename))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(MAX_PATH);
                FindExecutable(filename, null, sb);
                if (sb.Length > 0)
                {
                    return sb.ToString();
                }
            }
            return "";
        }
