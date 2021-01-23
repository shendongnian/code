    Thread t = new Thread(() => UpdateText(listBox1.Items));
    t.Start();
    private void UpdateText(ListBox.ObjectCollection items)
    {
       foreach (var item in items)
       {
          SetText(item.ToString());
          Thread.Sleep(1000);
       }
    }
