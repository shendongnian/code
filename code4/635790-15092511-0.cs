    private void button1_Click(object sender, EventArgs e)
            {
                for(int i=0;i<5;i++)
                    methode1();
            }
    public void methode1()
            {
                System.Windows.Forms.WebBrowser wBrowser = System.Windows.Forms.WebBrowser();
                wBrowser.DocumentCompleted +=webBrowser_DocumentCompleted;
                wBrowser.Navigate("http://www.test.com");
                a = 1;
            }
