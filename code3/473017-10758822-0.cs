    public class YourForm : Form
    {
      private sealed class YourData
      {
        public string SubKeyName { get; set; }
        public string Value { get; set; }
      }
    
      private ConcurrentQueue<YourData> queue = new ConcurrentQueue<YourData>();
      private void StartTreeViewUpdate_Click(object sender, EventArgs args)
      {
        Task.Factory.StartNew(WorkerThread);
        TreeViewUpdateTimer.Enabled = true;
      }
    
      private void TreeViewUpdateTimer_Tick(object sender, EventArgs args)
      {
        // Update in batches of 100 (or whatever) so that the UI stays
        // responsive.
        treeView1.BeginUpdate();
        for (int i = 0; i < 100; i++)
        {
          YourData value = null;
          if (queue.TryDequeue(value) && value != null)
          {
            treeView1.Nodes[value.SubKeyName].Nodes.Add(value.Value, value.Value)
          }
          else
          {
            // We're done.
            TreeViewUpdateTimer.Enabled = false;
            break;
          }
        }
        treeView1.EndUpdate();
      }
    
      private void WorkerThread()
      {
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
        {
          foreach (string subkey_name in key.GetSubKeyNames())
          {
            using (RegistryKey subkey = key.OpenSubKey(subkey_name))
            {
              foreach (string a in (string[])subkey.GetValue("Users", ""))
              {
                User u = new User(a);
                usrs.addUser(new User(a));
                wgs.addUserToWorkgroup(subkey_name, a);
                usrs.AddWorkGroupToUser(subkey_name, a);
                var data = new YourData();
                data.SubKeyName = subkey_name;
                data.Value = a;
                queue.Enqueue(data);
              }
              queue.Enqueue(null); // Indicate that queueing is done.
            }
          }
        }
      }
    }
