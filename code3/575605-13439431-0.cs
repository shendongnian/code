    try
    {
        sp.SaveCards(r, 2, card_Type_ID, SaveDate, 2);
    }
    catch (SqlException e) 
    {
      // Check if exception was raised because of a duplicate key and perform your logic
    }
    catch (Exception ex)
    {
      // Any other exceptions raised
    }
