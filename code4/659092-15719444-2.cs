        UserControl1.PriceChanged += new EventHandler<MyEventArgs>(page_PriceChanged);
        protected void page_PriceChanged(object source, MyEventArgs e)
        {
            Label1.Text = e.Price.ToString("C");
        }
    
