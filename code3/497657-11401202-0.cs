    /// <summary>
    /// Axis scales a min/max value appropriately for the purpose of graphs
    /// <remarks>Code taken and modified from http://peltiertech.com/WordPress/calculate-nice-axis-scales-in-excel-vba/</remarks>
    /// </summary>
    public struct Axis 
    {
        public readonly float min_value;
        public readonly float max_value;
        public readonly float major_step;
        public readonly float minor_step;
        public readonly int major_count;
        public readonly int minor_count;
        /// <summary>
        /// Initialize Axis from range of values. 
        /// </summary>
        /// <param name="x_min">Low end of range to be included</param>
        /// <param name="x_max">High end of range to be included</param>
        public Axis(float x_min, float x_max)
        {
            //Check if the max and min are the same
            if(x_min==x_max)
            {
                x_max*=1.01f;
                x_min/=1.01f;
            }
            //Check if dMax is bigger than dMin - swap them if not
            if(x_max<x_min)
            {
                float temp = x_min;
                x_min = x_max;
                x_max = temp;
            }
            //Make dMax a little bigger and dMin a little smaller (by 1% of their difference)
            float delta=(x_max-x_min)/2;
            float  x_mid=(x_max+x_min)/2;
            x_max=x_mid+1.01f*delta;
            x_min=x_mid-1.01f*delta;
            //What if they are both 0?
            if(x_max==0&&x_min==0)
            {
                x_max=1;
            }
            //This bit rounds the maximum and minimum values to reasonable values
            //to chart.  If not done, the axis numbers will look very silly
            //Find the range of values covered
            double pwr=Math.Log(x_max-x_min)/Math.Log(10);
            double scl=Math.Pow(10, pwr-Math.Floor(pwr));
            //Find the scaling factor
            if(scl>0&&scl<=2.5)
            {
                major_step=0.2f;
                minor_step=0.05f;
            }
            else if(scl>2.5&&scl<5)
            {
                major_step=0.5f;
                minor_step=0.1f;
            }
            else if(scl>5&&scl<7.5)
            {
                major_step=1f;
                minor_step=0.2f;
            }
            else
            {
                major_step=2f;
                minor_step=0.5f;
            }
            this.major_step=(float)(Math.Pow(10, Math.Floor(pwr))*major_step);
            this.minor_step=(float)(Math.Pow(10, Math.Floor(pwr))*minor_step);
            this.major_count=(int)Math.Ceiling((x_max-x_min)/major_step);
            this.minor_count=(int)Math.Ceiling((x_max-x_min)/minor_step);
            int i_1=(int)Math.Floor(x_min/major_step);
            int i_2=(int)Math.Ceiling(x_max/major_step);
            this.min_value=i_1*major_step;
            this.max_value=i_2*major_step;
        }
        public float[] MajorRange
        {
            get
            {
                float[] res=new float[major_count+1];
                for(int i=0; i<res.Length; i++)
                {
                    res[i]=min_value+major_step*i;
                }
                return res;
            }
        }
        public float[] MinorRange
        {
            get
            {
                float[] res=new float[minor_count+1];
                for(int i=0; i<res.Length; i++)
                {
                    res[i]=min_value+minor_step*i;
                }
                return res;
            }
        }
    }
