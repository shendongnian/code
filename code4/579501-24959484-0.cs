         public int TryCatchFinally(int a, int b)
        {
            try
            {
                int sum = a + b;
                if (a > b)
                {
                    throw new Exception();
                }
                else
                {
                    int rightreturn = 2;
                    return rightreturn;
                }
            }
            catch (Exception)
            {
                int ret = 1;
                return ret;
            }
            finally
            {
                int fin = 5;
            }
        }
