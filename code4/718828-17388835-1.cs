    public int[,] ConvertArray(int[] Input, int size)
    {
        int[,] Output = new int[(int)(Input.Length/size),size];
        System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\OutFile.txt");
        for (int i = 0; i < Input.Length; i += size)
        {
            for (int j = 0; j < size; j++)
            {
                Output[(int)(i / size), j] = Input[i + j];
                sw.Write(Input[i + j]);
            }
            sw.WriteLine("");
        }
        sw.Close();
        return Output;
    }
