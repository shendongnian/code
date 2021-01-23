    int ina;
    if (int.TryParse(txttea.Text, out ina))
    {
        int inb;
        if (int.TryParse(txtcoffee.Text, out inb))
        {
            //Ok, more code here
        }
        else
        {
            //got a wrong format, MessageBox.Show or whatever goes here
        }
    }
    else
    {
        //got a wrong format, MessageBox.Show or whatever goes here
    }
