        void Replace<T>(ref T[] source, IDictionary<T[], T[]> values)
        {
            int start = 0;
            int index = -1;
            foreach (var item in values)
            {
                start = 0;
                while ((index = IndexOfSequence<T>(source, item.Key, start)) >= 0)
                {
                    for (int i = index; i < index + item.Key.Length; i++)
                    {
                        source[i] = item.Value[i - index];
                    }
                    start = index + item.Key.Length + 1;
                }
            }
        }
        public int IndexOfSequence<T>(T[] source, T[] sequence, int start)
        {
            int j = -1;
            if (sequence.Length == 0)
                return j;
            for (int i = start; i < source.Length; i++)
            {
                if (source[i].Equals(sequence[0]) && source.Length >= i + sequence.Length)
                {
                    for (j = i + 1; j < i + sequence.Length; j++)
                    {
                        if (!source[j].Equals(sequence[j - i]))
                            break;
                    }
                    if (j - i == sequence.Length)
                        return i;
                }
            }
            return -1;
        }
