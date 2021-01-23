    In C#...
    
    using System;
    using System.IO;
    class Solution {
        static void Main(String[] args) {        
            for(int i=1;i<=100;i++)
            {                       
             string result=(i%3==0 && i%5==0) ? "FizzBuzz" : 
    		       (i%5==0) ? "Buzz" :
                           (i%3==0) ? "Fizz" : i.ToString();			
             Console.WriteLine(res);
            }
        }
    }
     
    
    In VB.NET...
    
    Imports System
    Imports System.IO
    
    Class Solution
        Private Shared Sub Main(ByVal args As String())
            For i As Integer = 1 To 100
                Dim res As String = If((i Mod 3 = 0 AndAlso i Mod 5 = 0), "FizzBuzz", If((i Mod 5 = 0), "Buzz", If((i Mod 3 = 0), "Fizz", i.ToString())))
                Console.WriteLine(res)
            Next
        End Sub
    End Class
