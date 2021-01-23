            try
            {
                return _queue.GetAllMessages().Length;
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(4000);
                return _queue.GetAllMessages().Length;
            }
