    void sender(object sender, DoWorkEventArgs e)
            {
                // DO SOMETHING ! 
    
    
            }
    
            [HttpPost]
            public string Validate()
            {
    
    
                var backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += Foo;
                backgroundWorker.RunWorkerAsync();
    
                return "OK";
    
    
    
    
    
            }
