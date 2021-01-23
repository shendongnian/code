      Task.Factory.StartNew(() => {
        try {
          string errorMsg;
          double connectionTime;
          var success = TestProxy("1.2.3.4",3128, out errorMsg, out connectionTime);
    
          //Log Result
        } catch (Exception ex) {
          //Log Error
        }
      });
