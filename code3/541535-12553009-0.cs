    public partial class Form1 : Form
    {
       public Form1()
        {
             web.ProgressChanged += new WebBrowserProgressChangedEventHandler(web_ProgressChanged);
        }
    private void web_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            
            <strong>double t = (100 * (double)e.CurrentProgress / (double)e.MaximumProgress);</strong>
            if (t < 0)
                return;
            int c = (int)t;
            progressBar.Value = c;
            if (c == 100)
            {
                label1.Text = "Done";                
            }
        }
    }
