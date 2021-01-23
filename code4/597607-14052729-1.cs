    if (!string.IsNullOrWhiteSpace(Textbox1.text))
    {
        int qty = Int32.Parse(Textbox1.text);
        double rate = Double.Parse(Textbox2.text);
        Textbox3.text = (rate* (double) qty).ToString();
    }
    else
    {
        //Give appropriate message to user for entering quantity in textbox 1
    }
