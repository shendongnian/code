    private readonly BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        
    protected void Page_Load(object sender, EventArgs e)
        {
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
        }
    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                timing();
            }
            catch
            {
            }
        }
    
        public void timing()
        {
            string tt = DateTime.Now.ToString("tt");
            string t = "";
            if (tt == "AM")
            {
                int hour = DateTime.Now.Hour;
                if ((hour >= 0) & (hour <= 11))
                {
                    t = "GOOD MORNING";
                }
            }
            else if (tt == "PM")
            {
                int hour = DateTime.Now.Hour;
                if ((hour >= 12) & (hour <= 15))
                {
                    t = "GOOD AFTERNOON";
                }
                else if ((hour >= 16) & (hour <= 23))
                {
                    t = "GOOD EVENING";
                }
            }
            Label1.Text = t;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    
    
    //SOURCE:
    
    <%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeFile="background.aspx.cs" Inherits="background" %> //Async="true"
