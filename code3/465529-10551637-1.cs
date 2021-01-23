    public class YourForm : Form
    {
      private ConcurrentQueue<UpdateInfo> queue = new ConcurrentQueue<UpdateInfo>();
    
      private void YourTimer_Tick(object sender, EventArgs args)
      {
        UpdateInfo value;
        listView1.BeginUpdate();
        while (queue.TryDequeue(out value)
        {
          this.listView1.Items[value.Number].SubItems[1].Text = value.Status;
        }
        listView1.EndUpdate();
      }
    
      private void SomeThread()
      {
        while (true)
        {
          UpdateInfo value = GetUpdateInfo();
          queue.Enqueue(value);
        }
      }
    
      private class UpdateInfo
      {
        public string User { get; set; }
        public string Status { get; set; }
        public string Proxy { get; set; }
        public int Number { get; set; }
      }
    }
