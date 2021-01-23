    private void Worker_TcpListener(object sender, ProgressChangedEventArgs e) {
      if (e.UserState != null) {
        int len = e.ProgressPercentage;
        string data = e.UserState.ToString();
        if (!String.IsNullOrEmpty(data) && (3 < len)) {
          string head = data.Substring(0, 3);
          string item = data.Substring(3);
          if (!String.IsNullOrEmpty(item)) {
            if (head == "BP:") {
              string[] split = data.Split(';');
              if (2 < split.Length) {
                string box = split[0].Substring(3); // Box Number
                string qty = split[1].Substring(2); // Quantity
                string customer = split[2].Substring(2); // Customer Name
                MyRoutine(box, qty, customer);
              }
            }
          }
        }
      }
    }
