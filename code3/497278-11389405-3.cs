    void ChangeColor(string menuItem)
    {
      switch(menuItem)
      {
        case "Test1":
          btn1.BackColor = Color.Orange;
          break;
        case "Test2":
          btn1.BackColor = Color.White;
          btn2.BackColor = Color.Orange;
          break;
         // and so on
      }
    }
