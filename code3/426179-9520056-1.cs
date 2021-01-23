    public void ButtonClick(object sender, EventArgs e)
    {
      Task t = new Task.Factory.StartNew(DoSomethingThatTakesTime);
      t.Wait();  
      //If you press Button2 now you won't see anything in the console 
      //until this task is complete and then the label will be updated!
      UpdateLabelToSayItsComplete();
    }
    
    public async void ButtonClick(object sender, EventArgs e)
    {
      var result = Task.Factory.StartNew(DoSomethingThatTakesTime);
      await result;
      //If you press Button2 now you will see stuff in the console and 
      //when the long method returns it will update the label!
      UpdateLabelToSayItsComplete();
    }
    
    public void Button_2_Click(object sender, EventArgs e)
    {
      Console.WriteLine("Button 2 Clicked");
    }
    
    private void DoSomethingThatTakesTime()
    {
      Thread.Sleep(10000);
    }
