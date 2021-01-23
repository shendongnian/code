        void strcpy(ref byte[] ar,int startpoint,string str)
        {
            try
            {
                int position = startpoint;
                byte[] tempb = Encoding.ASCII.GetBytes(str);
                for (int i = 0; i < tempb.Length; i++)
                {
                    ar[position] = tempb[i];
                    position++;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ER: "+ex.Message);
            }
        }
