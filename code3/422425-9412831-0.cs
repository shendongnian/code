        DateTime targetDate = DateTime.Now;
        public void ShowMessage()
        {
            if (DateTime.Now > targetDate)
            {
                targetDate = DateTime.Now.AddHours(12);
                MessageBox.Show("hello!");
            }
        }
