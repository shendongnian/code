    private void CardInfoDown_Completed(object sender, OpenReadCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(e.Result))
            {
                // I want get the url here,
                // How to do this?
                var client = sender as WebClient;
                if (client != null)
                {
                    var url = client.BaseAddress; //returns hhh.com
                }
                string strStream = reader.ReadToEnd();
            }
        }
