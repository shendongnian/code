    public static unsafe Segment[] Split(byte[] _src, byte value)
    {
        var _ln = _src.Length;
        if (_ln == 0) return new Segment[] { };
            
        fixed (byte* src = _src)
        {
            var segments = new LinkedList<Segment>(); // Segment[c];
            byte* last = src;
            byte* end = src + _ln;
            // TODO: handle last element
            *end = value; // value-termination
            var s = src;
            while (true)
            {
                s++;
                if (*s == value)
                {
                    int begin = (int) (last - src);
                    int length = (int) (s - last);
                    segments.AddLast(new Segment(_src, begin, length));
                    last = s + 1;
                    if (s == end)
                    {
                        // TODO : handle last element
                        break;
                    }
                }
            }
            return segments.ToArray();
        }
    }
