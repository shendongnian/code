    private void DisplayResults(MyItem myItem, Color color, string message)
    {
        this.listView1.Items.Add(
            new ListViewItem(
                new[]
                {
                    message, 
                    myItem.Line ,
                    myItem.CurrentThread.ToString(), 
                    Thread.CurrentThread.ManagedThreadId.ToString()
                }
            )
            {
                ForeColor = color
            }
        );
    }
