        public bool MoveNext()
        {
            index++;
            if (index < sc.stubs.Length)
            {
                return true;
            }
            else
            {
                index = -1;
                return false;
            }
        }
