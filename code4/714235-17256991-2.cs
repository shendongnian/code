    for (int y = 0; y < bitmap.Height; y += 3) // As we know the radius of the ball
    {
        for (int x = 0; x < bitmap.Width; x += 3) // We can increase this
        {
            if (bitmap.GetPixel(x, y) == black && bitmap.GetPixel(x, y + 3) == white)
            {
                Console.WriteLine("White Ball Found ({0},{1}) in {2}", x, y, stopwatch.Elapsed.ToString());
                break;
            }
        }
    }
