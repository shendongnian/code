    using System;
    using System.Globalization;
    using System.Diagnostics;
    
    namespace PerformanceTester
    {
       /// <summary>
       /// Helper class to print out performance related data like number of runs, elapsed time and frequency
       /// </summary>
       public static class Extension
       {
           static NumberFormatInfo myNumberFormat;
    
           static NumberFormatInfo NumberFormat
           {
               get
               {
                   if (myNumberFormat == null)
                   {
                       var local = new CultureInfo("en-us", false).NumberFormat;
                       local.NumberGroupSeparator = " "; // set space as thousand separator
                       myNumberFormat = local; // make a thread safe assignment with a fully initialized variable
                   }
                   return myNumberFormat;
               }
           }
    
           /// <summary>
           /// Execute the given function and print the elapsed time to the console.
           /// </summary>
           /// <param name="func">Function that returns the number of iterations.</param>
           /// <param name="format">Format string which can contain {runs} or {0},{time} or {1} and {frequency} or {2}.</param>
           public static void Profile(this Func<int> func, string format)
           {
    
               Stopwatch watch = Stopwatch.StartNew();
               int runs = func();  // Execute function and get number of iterations back
               watch.Stop();
    
               string replacedFormat = format.Replace("{runs}", "{3}")
                                             .Replace("{time}", "{4}")
                                             .Replace("{frequency}", "{5}");
    
               // get elapsed time back
               float sec = watch.ElapsedMilliseconds / 1000.0f;
               float frequency = runs / sec; // calculate frequency of the operation in question
    
               try
               {
                   Console.WriteLine(replacedFormat,
                                       runs,  // {0} is the number of runs
                                       sec,   // {1} is the elapsed time as float
                                       frequency, // {2} is the call frequency as float
                                       runs.ToString("N0", NumberFormat),  // Expanded token {runs} is formatted with thousand separators
                                       sec.ToString("F2", NumberFormat),   // expanded token {time} is formatted as float in seconds with two digits precision
                                       frequency.ToString("N0", NumberFormat)); // expanded token {frequency} is formatted as float with thousands separators
               }
               catch (FormatException ex)
               {
                   throw new FormatException(
                       String.Format("The input string format string did contain not an expected token like "+
                                     "{{runs}}/{{0}}, {{time}}/{{1}} or {{frequency}}/{{2}} or the format string " +
                                     "itself was invalid: \"{0}\"", format), ex);
               }
           }
    
           /// <summary>
           /// Execute the given function n-times and print the timing values (number of runs, elapsed time, call frequency)
           /// to the console window.
           /// </summary>
           /// <param name="func">Function to call in a for loop.</param>
           /// <param name="runs">Number of iterations.</param>
           /// <param name="format">Format string which can contain {runs} or {0},{time} or {1} and {frequency} or {2}.</param>
           public static void Profile(this Action func, int runs, string format)
           {
               Func<int> f = () =>
               {
                   for (int i = 0; i < runs; i++)
                   {
                       func();
                   }
                   return runs;
               };
               f.Profile(format);
           }
    
           /// <summary>
           /// Call a function in a for loop n-times. The first function call will be measured independently to measure
           /// first call effects.
           /// </summary>
           /// <param name="func">Function to call in a loop.</param>
           /// <param name="runs">Number of iterations.</param>
           /// <param name="formatFirst">Format string for first function call performance.</param>
           /// <param name="formatOther">Format string for subsequent function call performance.</param>
           /// <remarks>
           /// The format string can contain {runs} or {0},{time} or {1} and {frequency} or {2}.
           /// </remarks>
           public static void ProfileWithFirst(this Action func, int runs, string formatFirst, string formatOther)
           {
               func.Profile(1, formatFirst);
               func.Profile(runs - 1, formatOther);
           }
       }
    }
