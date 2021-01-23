           protected void Page_Load(object sender, EventArgs e)
             {
                StackTrace stackTrace = new StackTrace();
                string eventName = stackTrace.GetFrame(1).GetMethod().Name; // this will the event name.
                if (eventName == "button1_Click")
                  {
                    // code to increase the count;
                  }
              }
