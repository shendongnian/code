    public static void outputDetail<T>(DateTime previousTime, ref T[] array, 
                                       StreamWriter streamWriter) where T : struct
    {
        if (array.Any(a => !a.Equals(default(T))))
        {
            string outputString = string.Join(",", 
                                              previousTime.ToString("yyyy/MM/dd"),
                                              string.Join(",", array));
    
            streamWriter.WriteLine(outputString);
        }
        
        array = Enumerable.Repeat(default(T), array.Length).ToArray();
    }
