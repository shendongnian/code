    private void button1_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                SwitchTagWithText();
                var thisButton = sender as Button;
                if(thisButton.Text != lastButton.Text 
                     && thisButton.Tag.ToString() == lastButton.Tag.ToString())
                {
                    //two different buttons with the same tag were clicked in succession
                    thisButton.Enabled = false;
                    lastButton.Enabled = false;
                    lastButton = null;
                    return;
                }
                lastButton = thisButton;
            }
            else
            {
               lastButton = sender as Button;
            }
            
            SwitchTagWithText();
    
            buttoncount++;
            label2.Text = buttoncount.ToString();
        }
