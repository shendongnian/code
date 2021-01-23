    private void SomeWork() {
      // start the worker thread here
      while(!PollDone()) {
        progressBar1.Value = PollProgress();
        Application.DoEvents(); // keep the GUI responisive
      }
    }
