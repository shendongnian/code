    public void Button1_Click(..)
    {
      Add1().Wait(); // deadlocks
      Add2().Wait(); // does not deadlock
    }
