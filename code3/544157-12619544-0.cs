    public abstract class Number
    {
    }
    public static void outputDetail(DateTime previousTime, ref Number[] array, StreamWriter streamWriter)  //the parameter in here is not necessary, but want to maintain a similiarity in the TimeOfDay class
    {
        string outputString = previousTime.ToString("yyyy/MM/dd");
        Boolean bypass = true;
        for (int i = 1; i < array.Length - 1; i++)
        {
            outputString = outputString + "," + array[i].ToString();
            if (array[i] != 0)
                bypass = false;
        }
        if (bypass == false)
            streamWriter.WriteLine(outputString);
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = 0;
        }
    }
