    private static object listLocker = new object();
    void AddItemThreadSafe(string item)
    {
        this.Invoke((MethodInvoker)delegate
        {
            lock (listLocker)
            {
                listBoxCollection.Items.Add(item);
            }
        });
    }
    void RemoveItemThreadSafe()
    {
        this.Invoke((MethodInvoker)delegate
        {
            lock (listLocker)
            {
                listBoxCollection.Items.RemoveAt(0);
            }
        });
    }
