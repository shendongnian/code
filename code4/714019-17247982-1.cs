    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\WriteLines.txt",true))
        {
         yourlooping ..
		 {
                 if(rt>0)
                     {
                       t=t+delt1;
                       float re=ve1*delt1+(0.5f*gt*Mathf.Pow(delt1,2));
                       rt=rt-re;
                       ve1=vg1+gt*delt1;
                       gt=(G*M)/(rt*rt);
                       file.WriteLine(t + " " + rt + " " + vg1 + " " + gt + " " + re);
                       limit=true;
                     }
                  else
                     {
                      limit=false;
                     }
		
		 }
       }
