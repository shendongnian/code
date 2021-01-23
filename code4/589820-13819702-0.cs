        public string MahaleInsert(Mahales Mahale)
        {
            Thread t = new Thread(new ThreadStart(ThreadBody));
            t.Start();
            t.Join();
            return Mahale.OutMessage;
        }
        [STAThread]
        void ThreadBody()
        {
            try
            {
                Mahale.OutMessage = DA_Agency.MahaleInsertDB(Mahale);
                Mahale.OutMessage = "SuccessInsert";
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("violation of unique key constraint"))
                    Mahale.OutMessage = "MahaleInsUniqueError";
                else
                    throw;
            }
        }
        //////////////////////////// this in my aplication level  //////////////////
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                string messsage = GeneralMethod.CatchException(e.ExceptionObject as Exception);
                MessageClass.MessageBox(messsage);
            }
            catch
            {
            }
        }
