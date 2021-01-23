    object locker = new object(); // globally visible lock
    ...
    private void Disconnection(int id)
    {        
        lock(locker)
        {
            User client = connected[id];
            for (int i = id; i < no - 1; i++)
            {
                connected[i] = connected[i + 1];
            }
            client.Sock.Close();
            client.CLThread.Abort();
            no--;      
            MessageBox.Show(no.ToString());
        }
        //ui clean
    }
