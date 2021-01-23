        public static void DeleteRandom()
        {
            int count = _dataSource.Items.Count;
            if (count == 0) return;
            Random random = new Random();
            int toRemove = random.Next(count);
            _dataSource.Items.RemoveAt(toRemove);
            if (count == 1) return;
            // Moving 0 to 0 forces the list to update itself completely
            _dataSource.Items.Move(0, 0);
        }
