        if (curVersion == newVersion) {
            MessageBox.Show("No Update Needed");
        } else if (curVersion.CompareTo(newVersion) < 0)
        {
            string title = "New Update Avaliable";
            string question = "Download Now?";
            if (DialogResult.Yes == MessageBoxEx.Show(this, question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Process.Start(url);
            }
        }
