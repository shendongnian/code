    // += as in arithmetic addition
    int i = 3;
    i += 1;  // i now outputs 4
    
    // += as in programmatically attaching an event to a control 
    Button btn = new Button();
    btn.Click += new EventHandler(btn_Click); 
    
    private void btn_Click(object obj) { ... ; }
