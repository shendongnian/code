    ArraySegment<string> segment;
               
    for (int i = 0; i < source.Length; i += 100)
    {
        segment = new ArraySegment<string>(source, i, 100);
    
        // and to loop through the segment
        for (int s = segment.Offset; s < segment.Array.Length; s++)
        {
            Console.WriteLine(segment.Array[s]);
        }
    }
