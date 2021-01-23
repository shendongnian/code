    private void CardInfoDown_Completed(object sender, OpenReadCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(e.Result))
            {
                var url = (string)e.UserState;
                string strStream = reader.ReadToEnd();
            }
        }
    }
