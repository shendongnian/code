    int value1=0;
    int value2=0;
    int result;
    if (!Int32.TryParse(txtbox1.Text, out value1))
    {   
       MessageBox.Show("Not valid number");
       return;
    }  
    if (!Int32.TryParse(txtbox2.Text, out value2))
    {   
       MessageBox.Show("Not valid number");
       return;
    }
    mySum(value1,value2);
