      Calender obj = new Calender();
      obj.TopLevel = false;
 
      if (panel2.Controls.Count > 0)
      {
          panel2.Controls.Clear();
          panel2.Controls.Add(obj);
          obj.TopLevel = false;
          obj.Show();
      }
      else
      {
           obj.TopLevel = false;
           panel2.Controls.Add(obj);
           obj.Show();
      }
      panel2.Controls.add(new Label{
           Text = DateTime.Now
      });
