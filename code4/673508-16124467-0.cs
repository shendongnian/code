     public Color currentColor;       
     bool flag=false;
        private void ColorPickMouseDown(object sender, MouseEventArgs e)
        {
            if(flag==false)
            {
            flag=true
            Panel pnlSender = (Panel)sender;                   
            currentColor = pnlSender.BackColor;
           }
        }
        //assume mouse up for panles
        private void AttempsColorChanger(object sender, MouseEventArgs e)
        {
           if(flag==true)
           {  
            Panel pnl = (Panel)sender;
            pnl.BackColor = currentColor;
            flag=flase;
           }
        }
