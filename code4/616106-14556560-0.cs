    for (int i = 0; i < array.Count; i++)
    {
        listBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
            new Action(delegate() { listBox1.Items.Add(array[i]) });
    }
