using System;
public class PrimeChecker
{
    public static bool Prime(int m) 
{ 
    for (int i =2; i< m; i++)
        {
        if (m % i ==0)
            {
             return false ;
            }
        }
return true; 
    }
public static void Main()
{
        Console.WriteLine(Prime(13));
        
    }
}
