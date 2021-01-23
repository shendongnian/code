    private void CallMethod()
    {    
        obj.sumAsync(2,2);
        obj.sumAsyncCompleted += (s,e) =>
            {
                if (e.Error == null)
                {
                MessageBox.Show(e.Result.ToString());
            };
    }
