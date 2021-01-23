         public bool roomSelected()
        {
            int a = 0;
            foreach (RadioButton rb in GroupBox1.Controls)
            {
                if (rb.Checked == true)
                {
                    a = 1;
                }
    
            }
    
            if (a == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
