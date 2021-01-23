     Task<bool> t1 = new Task<bool>(() => testBB(ref _bbws_wrapper));
     t1.Start();
     Task cwt1 = t1.ContinueWith(task => { if (t1.Result == true) { this.ssi_bb_conn.BackColor = Color.Green;} else { this.ssi_bb_conn.BackColor = Color.Red; } }, TaskScheduler.FromCurrentSynchronizationContext());
    .....
    private static bool testBB(ref BBWebserviceWrapper _bbwsw)
        {
            try
            {
                //test the connections
                if (_bbwsw.initialize_v1() == true)
                {
                    if (_bbwsw.loginUser("XXXXXXXX", "XXXXXXXXX") == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
