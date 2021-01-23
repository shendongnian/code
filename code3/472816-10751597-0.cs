    public void ClickSS(object sender, EventArgs e)
        {
            textBox_ssn.SelectionLength = 1;
        }
        public void ButtonSS(object sender, KeyEventArgs e)
        {
            bool on_first_char = false;
            if (textBox_ssn.SelectionStart == 0) on_first_char = true;
            
            if (e.Key == Key.Right && textBox_ssn.SelectionStart < 10)
            {
                ++textBox_ssn.SelectionStart;
                textBox_ssn.SelectionLength = 1; //Without this, it will move around large blocks of selection
                if (textBox_ssn.SelectedText == "-") ++textBox_ssn.SelectionStart;
            }
            else if (e.Key == Key.Left && textBox_ssn.SelectionStart > 0)
            {
                --textBox_ssn.SelectionStart;
                textBox_ssn.SelectionLength = 1;
                if (textBox_ssn.SelectedText == "-") --textBox_ssn.SelectionStart;
            }
            else
            {
                string temp = "";
                switch (e.Key)
                {
                    case Key.D0:
                        temp = "0";
                        break;
                    case Key.D1:
                        temp = "1";
                        break;
                    case Key.D2:
                        temp = "2";
                        break;
                    case Key.D3:
                        temp = "3";
                        break;
                    case Key.D4:
                        temp = "4";
                        break;
                    case Key.D5:
                        temp = "5";
                        break;
                    case Key.D6:
                        temp = "6";
                        break;
                    case Key.D7:
                        temp = "7";
                        break;
                    case Key.D8:
                        temp = "8";
                        break;
                    case Key.D9:
                        temp = "9";
                        break;
                    case Key.Delete:
                        temp = "_";
                        break;
                    case Key.Back:
                        temp = "_";
                        if (textBox_ssn.SelectionStart > 0) --textBox_ssn.SelectionStart;
                        if (textBox_ssn.SelectedText == "-") --textBox_ssn.SelectionStart;
                        //else return; //or could do temp = selection text but only if selection length is 1 ectect
                        break;
                }
                if (temp != "")
                {
                    if (textBox_ssn.SelectionLength > 1)
                    {
                        string underscores = "";
                        foreach (char c in textBox_ssn.SelectedText)
                        {
                            if (c == '-') underscores += "-";
                            else underscores += "_";
                        }
                        textBox_ssn.SelectedText = underscores;
                        textBox_ssn.SelectionLength = 1;
                    }
                    
                    if (textBox_ssn.SelectedText == "-") ++textBox_ssn.SelectionStart;
                    if (textBox_ssn.SelectionLength == 1)
                    {
                        if (!(on_first_char && e.Key == Key.Back)) textBox_ssn.SelectedText = temp;
                        if (e.Key == Key.Delete) ;
                        else if (e.Key == Key.Back)
                        {
                            if (textBox_ssn.SelectionStart > 0)
                            {
                                //--textBox_ssn.SelectionStart;
                                if (textBox_ssn.SelectedText == "-") --textBox_ssn.SelectionStart;
                            }
                        }
                        else
                        {
                            ++textBox_ssn.SelectionStart;
                            if (textBox_ssn.SelectedText == "-") ++textBox_ssn.SelectionStart;
                        }
                    }
                }
            }
        }
