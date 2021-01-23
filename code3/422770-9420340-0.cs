    class CoWorker
    {
       public string Name { get; set; }
    }
    
    class Partner
    {
       public string Name { get; set; }
    }
    
    private void button1_Click(object sender, RoutedEventArgs e)
    {
       CoWorker cw = new CoWorker();
       cw.Name = "David Stratton";
       Partner p = new Partner();
       p.Name = "David Stratton";
    
       label1.Content = cw.Equals(p).ToString();  // sets the Content to "false"
    }
