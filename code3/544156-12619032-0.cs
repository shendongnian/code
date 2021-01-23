        public static void outputDetail<T>(DateTime previousTime, ref T[] array, StreamWriter streamWriter)  //the parameter in here is not necessary, but want to maintain a similiarity in the TimeOfDay class
        {
            var outputString = new StringBuilder(previousTime.ToString("yyyy/MM/dd"));
            Boolean bypass = true;
            
            for (int i = 1; i < array.Length - 1; i++)
            {
                outputString.Append("," + array[i]);
                if (!(array[i].Equals(default(T))))
                    bypass = false;
            }
            if (bypass == false)
                streamWriter.WriteLine(outputString);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default(T);
            }
        }
