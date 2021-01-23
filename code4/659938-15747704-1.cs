    using System;
    using System.Text;
    namespace Practice
    {
    public class Test
    {
      static double[] ldat = {0.0, 1.1, 1.1, 1.1, 10.5};
      
   
      public static void Main(string[] args)
      {
        //Code you'll need starts here.
         int firstEqualIndex = 0;
	for(int i = 0 ; i < ldat.Length ; i ++)
	{
	if (i > 0)
	{
    		if(ldat[i] == ldat[i - 1])
    		{
        		if(firstEqualIndex == 0)
        		{
            			firstEqualIndex = i - 1;
        		}
    		}
    	else //They are not equal
    	{
        	//Figure out the average.
        	double average = (ldat[i] + ldat[firstEqualIndex]) / (Double)((i - firstEqualIndex));
        	for(int j = firstEqualIndex + 1; j < i; j++)
        	{
            		ldat[j] += average;
        	}
        	firstEqualIndex = 0;
    	}
	}
      }
       //And ends here.
	StringBuilder builder = new StringBuilder();
	foreach (double entry in ldat)
	{
	    // Append each int to the StringBuilder overload.
	    builder.Append(entry).Append(", ");
	}
	string result = builder.ToString();
	Console.WriteLine(result);
      }
    }
    }
