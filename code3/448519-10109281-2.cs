     protected void Button1_Click(object sender, EventArgs e)
     {
        lock (Session.SyncRoot)
        {
           int numberInSession = (int) Session["number_x"];
           int number2 = randomNumber(1, 10);
           int newNumber = numberInSession + number2;
           Session["number_x"] = newNumber 
         }
    }
