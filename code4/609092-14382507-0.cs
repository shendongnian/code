        private void dbg(string s)
        {
            System.Diagnostics.Debug.WriteLine("AddNewTab({0}): {1}", 
                Thread.CurrentThread.ManagedThreadId, s);
        }
        public void AddNewTab(int id)
        {
            try
            {
                dbg("entered");
                if (this.tabControl1.InvokeRequired)
                {
                    new Thread(delegate() { try {
                            CWU cb = new CWU(AddNewTab);
                            dbg("calling Invoke");
                            this.tabControl1.Invoke(cb, id);
                            dbg("Invoke returned");
                        } catch (Exception ex) { dbg("" + ex); }
                    }).Start();
                    dbg("created sub-thread");
                }
                else
                {
                    dbg("setting tabpage.Text");
                    User ToChatWith = ContactsHelper.AllFriends
                        .Find(e => e.ID == id);
                    tabpage.Text = ToChatWith.ToString();
                    dbg("adding tab");
                    this.tabControl1.TabPages.Add(tabpage);
                    this.tabControl1.SelectTab(tabpage);
                    dbg("done adding tab");
                }
                dbg("leaving");
            }
            catch (Exception ex)
            {
                dbg("" + ex);
            }
        }
