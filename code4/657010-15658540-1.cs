    private void rtb_TextChanged(object sender, EventArgs e)
    {
        char c = rtb.Text.ElementAt(rtb.Text.Length);
        if(c == mystring.ElementAt(mystring.Length))
          //is equal
        mystring = rtb.Text; //save string for next comparison
    }
