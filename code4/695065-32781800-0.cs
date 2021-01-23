    namespace WindowsFormsApplication1
    {
      public partial class ComTester : Form
      {
        public int []sAvgArr=new int [251];
        public int sAvgAdr,sAvgCnt;
        private void Calc_Values(object sender, int v)//v is value
        {
            int n = AverageLength;
            if (n > 250) n = 250;//average buffer maksimum
            if (n > 0)
            {
                sAvgArr[sAvgAdr] = v;
                sAvgAdr += 1;
                sAvgCnt += 1;
                if (n <= sAvgAdr) sAvgAdr = 0;
                if (n <= sAvgCnt) sAvgCnt = n;
                n = sAvgCnt;
                int f = 0, l = 0; ;
                for (l = 0; l < n; l += 1)
                    f += sAvgArr[l];
                f = f / sAvgCnt;
                sAvgVal = f;
            }
            else 
            {
                sAvgVal=v;
            }
        }
      }
    }
