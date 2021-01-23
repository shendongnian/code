     private void button1_Start_Click(object sender, EventArgs e)//this is just the Pseudocode
            {
                GetData();
                button1_Start.Enable = false;
            }
    
            private void GetData()
            {
                webBrowser1.Navigate("inputURLID");
            }
    
            private void SendData()
            {
                webBrowser1.Document.GetElementById("subject").SetAttribute("value", textBox2_Subject.Text);//To (username)
                webBrowser1.Document.GetElementById("message").SetAttribute("value", richTextBox1.Text);//Subject
                webBrowser1.Document.GetElementById("Submit").InvokeMember("click");//Message
                button1_Start.Enable = true;
            }
    
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                SendData();
            }
