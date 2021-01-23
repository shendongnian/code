    bool result = Int32.TryParse(Session["Enq_ID"].ToString(), out number);
    if (result)
    {
        hotelOBJ.FillbyQueryEnquiry1(number, txtClientph, txtClientAddress );
    }
    else
    {
        Console.WriteLine("Attempted conversion of '{0}' failed.",
                           Session["Enq_ID"].ToString());
    }
