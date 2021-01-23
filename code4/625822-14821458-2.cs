    int firstNum = int.Parse(radTextBoxFirstNumber.Text);
    int secondNum = int.Parse(radTextBoxSecondNumber.Text);
    int delay = int.Parse(radTextBoxFloodDelay.Text);
    var task = Task.Factory.StartNew(() =>
    {
        int total;
        Parallel.For(0, int.Parse(radTextBoxFloodRequests.Text), 
        () => 0,
        (i, loopState, localState) =>
        {
            return localState + TaskRequestWithResult(firstNum, secondNum, delay, i);
        },
        localTotal => Interlocked.Add(ref total, localTotal);
        return total;
    };
    var continuation = task.ContinueWith(
                    antecedent =>
                    {
                        int total = antecedent.Result;
                        Debug.Print("Finished - Sum of all results is: " + total);
                        MessageBox.Show("Finished - Sum of all results is: " + total);                     
                    });  // Can use scheduler here if you want to update UI values
