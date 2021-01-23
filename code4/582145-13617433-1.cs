    List<ListViewItems> list = new List<ListViewItems>();
    Object myLock = new Object();
    Parallel.For(0, 10000, (j,loopState) =>
            {
                int id1 = getid(names[j].ToString(), 101);
                Parallel.For(0, 10000, (t,loopState1) =>
                    {
                        generate_firstACV5A(id1, nvisit(id1), names[j].ToString());
                        int id2 = getid(names[t].ToString(), 10000);
                        if (id1 == id2) { }
                        else
                        {
                            generate_firstACV5B(id2, nvisit(id2), names[t].ToString());
                        }
    
                        if (Enumerable.SequenceEqual(ACV5BFirst, ACV5Afirst) == true)
                        {
                            if (count == 0)
                         {
                             safecount++;
                             if (safecount == 4) {
                                 ListViewItem it = new ListViewItem(getid(names[j].ToString(), 1000).ToString());
                                 it.SubItems.Add(names[j].ToString());
                                 lock (myLock )
                                 {
                                     list.Add(it); 
                                 }
                                 
                                 loopState1.Break();
                             }
    
    
                           }
                        }
                    });
    listView3.Items.AddRange(list.ToArray());
