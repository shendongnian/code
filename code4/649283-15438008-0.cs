        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_keys.Count > 0)
            {
                 //Here get all keys and play the sound using threads
                 _keys.Clear();
            }
        }
