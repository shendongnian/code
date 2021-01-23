    // your library
    class Foo {
       public event EventHandler ComputeCompleted = (sender, e) => { };
        
       public void Compute() {
          // kick off work on a background thread
          // possibly using the BackgroundWorker object
          var bw = new BackgroundWorker();      
          bw.RunWorkerCompleted += RunWorkerCompleted;
          bw.RunWorkerAsync(); 
       }
       private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            ComputeCompleted(this, new object()); 
       }
    }
    // calling code
    Foo foo = new Foo();
    foo.ComputeCompleted += Completed;
    foo.Compute();
    private void Completed(object Sender, EventArgs e) {
       // process the result here
    }
