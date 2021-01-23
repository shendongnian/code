    private void tbWord_TextChanged(object sender, TextChangedEventArgs e) 
     { 
    	Task.Factory.StartNew(() =>
    	{
    		return Wiki.DoWrok(tbWord.Text);
    	}).ContinueWith(taskState =>
    	{
    		tbResponce.Text = taskState.Result;
    	}, TaskScheduler.FromCurrentSynchronizationContext());
     } 
