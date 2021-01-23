        public IEnumerator<MT101> GetEnumerator()
        {
            foreach (MT101 m in this.Message101)
            {
                 yield return m;
            }
        }
