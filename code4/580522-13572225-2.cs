        Invoke(new MethodInvoker(
                       delegate
                       {
                           string[] row1 = { proxy, query, page, links };
                           ListViewItem item = listView1.Items.Add(threadNumber.ToString());
                           item.SubItems.AddRange(row1);
                           item.Tag = threadNumber.ToString(); // or whatever you want to search by
                           index = listView1.Items.Count - 1;
                       }
                       ));
