    private void SomeWork() {
      // start the worker thread here
      while(!PollDone()) {
        progressBar1.Value = PollProgress();
        System.Threading.Thread.Sleep(300); // give the polled thread some time to work instead of responding to your poll
        Application.DoEvents(); // keep the GUI responisive
      }
    }
