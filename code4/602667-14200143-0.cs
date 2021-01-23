    button.Tag = i;
    button.Click += handleTheClick;
    
    ...
    
    private void handleTheClick(object sender, EventArgs e){
        Button btn = sender as Button;
        int row = (int)btn.Tag;
    }
