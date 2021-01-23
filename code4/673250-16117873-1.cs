    private void checkBox1_Checked(object sender, RoutedEventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
    
        if (!m_bChkUpdating)
        {
            m_bChkUpdating = true;
            switch (chk.Name)
            {
                case "checkBox1":
                    checkBox2.IsChecked = true;
                    checkBox3.IsChecked = true;
                    checkBox4.IsChecked = true;
                    checkBox5.IsChecked = true;
                    break;
                default:
                    //  chk.IsChecked = true;
                    if (checkBox2.IsChecked == true &&
                        checkBox3.IsChecked == true &&
                        checkBox4.IsChecked == true &&
                        checkBox5.IsChecked == true)
                    {
                        checkBox1.IsChecked = true;
                    }
                    else
                    {
                        checkBox1.IsChecked = false;
                    }
                    break;
            }
            m_bChkUpdating = false;
        }
                       
    }
    
    private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        if (!m_bUnChkUpdating)
        {
            m_bUnChkUpdating = true;
    
            switch (chk.Name)
            {
                case "checkBox1":
                    checkBox2.IsChecked = false;
                    checkBox3.IsChecked = false;
                    checkBox4.IsChecked = false;
                    checkBox5.IsChecked = false;
                    break;
                default:
                    // chk.IsChecked = false;
                    if (checkBox2.IsChecked == false ||
                        checkBox3.IsChecked == false ||
                        checkBox4.IsChecked == false ||
                        checkBox5.IsChecked == false)
                    {
                        checkBox1.IsChecked = false;
                    }
                    else
                    {
                        checkBox1.IsChecked = true;
                    }
                    break;
            }
    
            m_bUnChkUpdating = false;
        }
    }    
  
