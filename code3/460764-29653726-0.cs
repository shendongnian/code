    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             Dictionary<string, string> myDictionary = new Dictionary<string, string>();
             myDictionary = e.Parameter as Dictionary<string, string>;
             timeTB.Text = myDictionary["time"].ToString();
             messageTB.Text = myDictionary["message"].ToString();
        }
 
