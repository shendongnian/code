    private Queue<Button> Button_Queue = new Queue<Button>();
    private bool isProcessing = false;
    private void Button_Click((object sender, EventArgs e){
    if(isProcessing){
        Button_Queue.Enqueue(this);
    }
    else
    {
        isProcessing = true;
    
        // code here
    
        isProcessing = false;
        while(Button_Queue.Count > 0){
            Button_Queue.Dequeue().PerformClick();
        }
    }
