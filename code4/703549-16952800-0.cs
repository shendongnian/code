    bool documentCompleted = false;
    private void button1_Start_Click(object sender, EventArgs e)
    {
        webBrowser1.Navigate(inputURLID);
        WaitForDocumentCompleted();
        SendData();
        WaitForDocumentCompleted();
    }
    private void WaitForDocumentCompleted()
    {
        while (!documentCompleted)
        {
            Thread.Sleep(100);
            Application.DoEvents(); 
        }
        documentCompleted = false;
    }
    private void SendData()
    {
        webBrowser1.Document.GetElementById("subject").SetAttribute("value", textBox2_Subject.Text);//To (username)
        webBrowser1.Document.GetElementById("message").SetAttribute("value", richTextBox1.Text);//Subject
        webBrowser1.Document.GetElementById("Submit").InvokeMember("click");//Message
    }
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        documentCompleted = true;
    }
