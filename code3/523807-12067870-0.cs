        private void cmdGo_Click(object Sender, EventArgs E)
        {
            //  txtSearch.Text = "*.docx";
            string[] sFiles = SearchForFiles(@"C:\Documents and Settings\Admin\Desktop\test", txtSearch.Text);
            foreach (string sFile in sFiles)
            {
                Process.Start(sFile);
            }
        }
        private static string[] SearchForFiles(string DirectoryPath, string Pattern)
        {
            return Directory.GetFiles(DirectoryPath, Pattern, SearchOption.AllDirectories);
        }
