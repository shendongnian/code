    private static bool CompareCharBuffers(
        char[] buffer,
        int headPosition,
        char[] stringChars)
    {
        // null checking and length comparison ommitted
        var same = true;
        var bufferPos = headPosition;
        for (var i = 0; i < stringChars.Length; i++)
        {
            if (!stringChars[i].Equals(buffer[bufferPos]))
            {
                same = false;
                break;
            }
            bufferPos = ++bufferPos % (buffer.Length - 1);
        }
        return same;
    }
