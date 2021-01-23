        private void Dowork()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (i < 10)
                {
                    Thread.Sleep(1000);
                    UpdateUI(i.ToString());
                    i++;
                }
            });
        }
