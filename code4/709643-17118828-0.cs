    Bitmap image = new Bitmap(@"Input.png");
    var colourCount = new int[3];
    Parallel.For(0, image.Width,
        // localInit: The function delegate that returns the initial state
        //            of the local data for each task.
        () => new int[3],
        // body: The delegate that is invoked once per iteration.
        (int x, ParallelLoopState state, int[] localColourCount) =>
        {
            for (var y = 0; y < image.Height; y++)
            {
                switch (image.GetPixel(x, y).ToArgb())
                {
                    case (int)colours.red: localColourCount[0]++; break;
                    case (int)colours.white: localColourCount[1]++; break;
                    case (int)colours.black: localColourCount[2]++; break;
                    default: throw new ArgumentOutOfRangeException(
                                 string.Format("Unexpected colour found: '{0}'", 
                                 image.GetPixel(x, y).ToArgb()));
                }
            }
        },
        // localFinally: The delegate that performs a final action
        //               on the local state of each task.
        (int[] localColourCount) =>
        {
            // Accessing shared variable; synchronize access.
            lock (colourCount)
            {
                for (int i = 0; i < 3; ++i)
                    colourCount[i] += localColourCount[i];
            }
        });
