    public void WriteStartAttribute(params string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }
    // this works:
    writer.WriteStartAttribute(writeInfo[1], writeInfo[2], writeInfo[4]);
