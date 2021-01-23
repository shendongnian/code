    private void AddToListViewThread(string user, string status, int threadNumber)
    {
        Invoke(new MethodInvoker(
                       delegate
                       {
                           listView2.BeginUpdate();
                           int i = SearchItem(listView2, threadNumber);
                           if ( i > -1)
                           {
                           this.listView2.Items[i].SubItems[1].Text = user;
                           this.listView2.Items[i].SubItems[2].Text = status;
                           }
                           listView2.EndUpdate();
                       }
                       ));
    }
    private void RemoveFromListViewThread(int threadNumber)
    {
        Invoke(new MethodInvoker(
                       delegate
                       {
                           listView2.BeginUpdate();
                           int i = SearchItem(listView2, threadNumber);
                           if ( i > -1)
                           {
                               this.listView2.Items.RemoveAt(i);
                           }
                           listView2.EndUpdate();
                       }
                       ));
    }
   
    private int SearchItem(ListView list, int id)
    { 
             for (int i  = 0; i < list.Items.Count; i++) // I used sequential search but you can implement binary instead
             {
                if (((int)list.Items[i].Tag) == id) return i;
             }
             return -1;
    }
