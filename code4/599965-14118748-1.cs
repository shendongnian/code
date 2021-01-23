        private bool IsDoubleNotAnInt(double num)
        {
            if ((num % 1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
