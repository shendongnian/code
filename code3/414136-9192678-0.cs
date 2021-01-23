    public void SomeMethod() {
      int myImportantVariable = 5;
      System.Net.Sockets.Socket s;
      s.BeginReceive(buffer, offset, size, SocketFlags.None, new new AsyncCallback(OnDataReceived), myImportantVariable);
    }
    private void OnDataReceived(IAsyncResult result) {
      Console.WriteLine("My Important Variable was: {0}", result.AsyncState); // Prints 5
    }
