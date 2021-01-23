    List<BookingObject> bo = new List<BookingObject>();
      DateTime dt;
      foreach (BookingObject book in bo)
      {
          dt = book.starttime;
          
      }
      //starttime is DateTime
      TextBox1.Text = Convert.ToString(dt.Hour);
