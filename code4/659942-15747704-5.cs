        using System;
        using System.Text;
        namespace Practice
        {
            public class Hello
            {
                static double[] ldat = {2.0,2.0,2.00,2.0,2.0,17.0};
                static double[] ldat2 = {2.0,3.0,4.00,4.0,7.0,19.0};
                static double[] ldat3 = {0.0, 0.0, -5.0, -5.0, -11.0, -11.0, -20};
                public static void Main(string[] args)
                {
                    test(ldat);
                    test(ldat2);
                    test(ldat3);
                }
                public static void test(double[] array){
                    //Use Code from here.....
                    int firstEqualIndex = -1;
                    for(int i = 1; i < array.Length ; i ++)
                    {
                        if (i > 0)
                        {
                            if(array[i] == array[i - 1])
                            {
                                if(firstEqualIndex == -1)
                                {
                                    firstEqualIndex = i - 1;
                                }
                            }
                            else //They are not equal
                            {
                                //Figure out the average.
                                if(firstEqualIndex >= 0)
                                {
                                    double average = (array[i] - array[firstEqualIndex]) / (Double)((i - firstEqualIndex));
                                    int k = 0;
                                    for(int j = firstEqualIndex; j < i; j++)
                                    {
                                        array[j] += average * k;
                                        k++;
                                    }
                                    firstEqualIndex = -1;
                                }
                            }
                        }
                    }
                    //..... to here.
                    StringBuilder builder = new StringBuilder();
                    foreach (double entry in array)
                    {
                        // Append each int to the StringBuilder overload.
                        builder.Append(entry).Append(", ");
                    }
                    string result = builder.ToString();
                    Console.WriteLine(result);
                }
            }
        }	   
	  
