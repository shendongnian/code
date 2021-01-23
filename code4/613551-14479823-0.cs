    //Action<in Exception> : Make the delgate take an exception, then throw it
    Action<Exception> myact = (ex => { throw ex; });
    //Pass a new Exception with the message test "Test" that will be thrown
    Task myactTask = Task.Factory.StartNew(() => myact(new Exception("Test")));
    try
    {
      myactTask.Wait();
      Console.WriteLine(myactTask.Id.ToString());
      Console.WriteLine(myactTask.IsCompleted.ToString());
    }
    catch (Exception ex)
    {
      //Writes out "Test"
      Console.WriteLine(ex.Message);
      throw ex;
    }
