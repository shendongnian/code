    private Timer t;
    void OnLoad(object sender, EventArgs e)
    {
        t = new Timer();
        t.Interval = 5000;
        t.Tick += new EventHandler(t_Tick);
    }
    private bool _hidden = false;
    
    void t_Tick(object sender, EventArgs e)
    {
        if(!_hidden)
        {
             Cursor.Hide();
             t.Interval = 500;
        }
        else
        {
             if(--some parameter---)
                  Cursor.Show();
        }
    }
            
