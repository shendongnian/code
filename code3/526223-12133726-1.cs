    public static unsafe Segment[] Split2(byte[] _src, byte value)
    {
        var _ln = _src.Length;
        if (_ln == 0) return new Segment[] { };
            
        fixed (byte* src = _src)
        {
            var segments = new LinkedList<Segment>(); // Segment[c];
            byte* last = src;
            byte* end = src + _ln - 1;
            byte lastValue = *end;
            *end = value; // value-termination
            var cur = src;
            while (true)
            {
                if (*cur == value)
                {
                    int begin = (int) (last - src);
                    int length = (int) (cur - last + 1);
                    segments.AddLast(new Segment(_src, begin, length));
                    last = cur + 1;
                    if (cur == end)
                    {
                        if (lastValue != value)
                        {
                            *end = lastValue;
                        }
                        break;
                    }
                }
                cur++;
            }
            return segments.ToArray();
        }
    }
