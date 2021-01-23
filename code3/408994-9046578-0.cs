    public void DisplayTime(string message) {
      var index = 0;
      var timer = new System.Timers.Timer(5000);
      timer.Elapsed += delegate { 
        if (index < message.Length) {
          Console.Write(message[index]);
          index++;
        } else {
          timer.Enabled = false;
          timer.Dispose();
        }
      };
      timer.Enabled = true;
    }
