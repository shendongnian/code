     for (int j = 0; j < aNum; j++)
            {
                //here is loop-unrolling for b
                b[0] += a[j];
                b[1] += a[j + 3];
                b[2] += a[j + 6];
            }
      for(k=0;k<max;k++)
      {
      for (int j = 0; j < aNum; j++)
            {
                //without loop-unrolling
                b[k] += a[j+k*3];
                
            }
       }
