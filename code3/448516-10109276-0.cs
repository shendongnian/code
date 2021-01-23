    protected void Button1_Click(object sender, EventArgs e)
    {
        int number2 = randomNumber(1, 10);
        if(Session["number_x"] != null)
        {
            int number1 = Int.Parse(Session["number_x"]);
            Session["number_x"] = number1 + number2;
        }
        else
        {
            Session["number_x"] = number2;
        }
    }
