    private int _counter;
    private int _currentIndex;
           
    private void timer1_Tick(object sender, EventArgs e)
            {
                    switch (_counter)
                    {
                        case 1:
                           form.Text = "Happy Birthday Goose!!!";
                           hBDLabel.Text = "Happy Birthday Goose!";
        
                        case 2:
                            timer1.Interval = 3000;
                        case 3:
                            youAreLabel.Text = "You are...";
                        case 4:
                            if (stringlist.count = (_currentIndex -1))
                            {
                                timer1.Enabled = false;
                            }else {
                                 mainLabel.Text = e;
                                 timer1.Interval = 1000;
                               return;
                            }
    
                            }
            
                   _counter ++;
               
        }
