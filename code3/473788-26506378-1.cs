        // usage on textbox
        public void UpdateTextBox1(String text)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(textBox1, () => UpdateTextBox1(text))) return;
            textBox1.Text = ellapsed;
        }
        //Or any control
        public void UpdateControl(Color c,String s)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(myControl, () => UpdateControl(c,s))) return;
            myControl.Text = s;
            myControl.BackColor = c;
        }
