    //Insert link to test
    richTextBoxEx1.InsertLink("StackOverFlow", "http://www.stackoverflow.com");
    //LickClicked event handler
    private void richTextBoxEx1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
    {
            string[] s = e.LinkText.Split(new string[]{@"#http://"}, StringSplitOptions.None);
            if (s.Length == 2)
            {
                s[1] = "http://" + s[1];
                MessageBox.Show("A link has been clicked.\nThe link text is '" + s[0] + "'\nThe link URL is '" + s[1] + "'");
                System.Diagnostics.Process.Start(s[1]);//Try visiting the link.
            }
    }
