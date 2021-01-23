    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                object input = e.Argument;
                string f = GetUrl(input);
                this.Invoke(new MethodInvoker(delegate { label2.Text = "Website To Crawl: "; }));
                this.Invoke(new MethodInvoker(delegate { label4.Text = f; }));
                if (offlineOnline == true)
                {
                    offlinecrawling(f, levelsToCrawl, e);
                }
                else
                {
                    webCrawler(f, levelsToCrawl, e);
                }
            }
