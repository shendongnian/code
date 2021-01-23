    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var restClient = new RestClient("http://tumblr.com/api/write");
        foreach (string item in queueBox.Items)
        { 
            //This should be inside the foreach 
            //as it is your loop that will check for cancel. 
            //Your code is procedural once it is in the backgroundworker
            //so it would never return to the spot you had it
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                MessageBox.Show("You pressed Cancel.");
                return;
            }
            var request = new RestRequest(Method.POST);
            //I believe Json is default for Restsharp, but you would have to play with it
            request.RequestFormat = DataFormat.Json; //I don't know if this line is necessary
            request.AddParameter("email", usernameBox.Text);
            request.AddParameter("password", passwordBox.Text);
            request.AddParameter("type", "photo");
            request.AddFile("data", FolderName + "\\" + item);
            //If you just pass in item to the below Func, it will be a closure
            //Meaning, any updates in the loop will propogate into the Action
            var newItemToAvoidClosure = item;
            //To use Async, you set up the callback method via a delegate
            //An anonymous method is as good as any here
            restClient.ExecuteAsync(request, 
                response=>
                { 
                    //Maybe you should do something with the response?
                    //Check the status code maybe?
                    doneBox.Invoke(new UpdateTextCallback(this.UpdateText),
                        new object[] { newItemToAvoidClosure });
                }
            );
        }
    }
