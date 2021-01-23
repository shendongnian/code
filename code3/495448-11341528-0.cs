        static IEnumerable<Tuple<int, int>> GetTextElementSegments(string value)
        {
            int[] elementOffsets = StringInfo.ParseCombiningCharacters(value);
            int lastOffset = -1;
            foreach (int offset in elementOffsets)
            {
                if (lastOffset != -1)
                {
                    int elementLength = offset - lastOffset;
                    Tuple<int, int> segment = new Tuple<int,int>(lastOffset, elementLength);
                    yield return segment;
                }
                lastOffset = offset;
            }
            if (lastOffset != -1)
            {
                int lastSegmentLength = value.Length - lastOffset;
                Tuple<int, int> segment = new Tuple<int, int>(lastOffset, lastSegmentLength);
                yield return segment;
            }
        }
        static void Main(string[] args)
        {
            string input = "t\u0301e\u0302s\u0303t\u0304";
            StringBuilder resultBuilder = new StringBuilder(input.Length);
            var segments = GetTextElementSegments(input);
            foreach (var segment in segments.Reverse())
            {
                resultBuilder.Append(input, segment.Item1, segment.Item2);
            }
            Debug.Assert(resultBuilder.ToString() == "t\u0304s\u0303e\u0302t\u0301s");
        }
