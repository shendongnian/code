             List<WP7Phone> data = new List<WP7Phone>();
                foreach (lines l in result)
                {
                    WP7Phone w7 = new WP7Phone();
                    w7.Name = l.line.TrimStart();
                    
                    w7.Image = "images/thump.jpg";
                    msg.Add(w7);
                }
                this.autoCompleteBox1.ItemsSource = data;
       public class WP7Phone
     {
        public string Name
      {
        get;
        set;
    }
    public string Image1
    {
        get;
        set;
    }
}
