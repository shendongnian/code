    int count = 0;
    string st = "Hi, these pretzels are making me thirsty; drink this tea. Run like heck. It's a good day.";
    foreach(char c in st) {
      if(char.IsLetter(c)) {
        count++;
      }
    }
    lblResult.Text = count.ToString();
