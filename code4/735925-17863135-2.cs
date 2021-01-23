        var bufferArray = new string[] {"43480170", "41CA0000" };
        float[] dblBffrArry = new float[bufferArray.Length];
        for (int i = 0; i < bufferArray.Length; i++)
        {
            uint parsed = uint.Parse(bufferArray[i], NumberStyles.AllowHexSpecifier);
            // following two lines are the missing steps in your loop
            byte[] byteArray = BitConverter.GetBytes(parsed);
            float floatValue = BitConverter.ToSingle(byteArray, 0);
            // ---- 
            dblBffrArry[i] = floatValue;
        }
        foreach (var floatValue in dblBffrArry)
        {
            Console.Write("{0}-",floatValue);
        }
