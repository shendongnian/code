    public static class AscendingMinima
    {
        private struct MinimaValue
        {
            public int RemoveIndex { get; set; }
            public double Value { get; set; }
        }
        public static double[] GetMin(this double[] input, int window)
        {
            var queue = new Deque<MinimaValue>();
            var result = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                var val = input[i];
                while (queue.Count > 0 && i >= queue[0].RemoveIndex)
                    queue.RemoveFromFront();
                while (queue.Count > 0 && queue[queue.Count - 1].Value >= val)
                    queue.RemoveFromBack();
                queue.AddToBack(new MinimaValue{RemoveIndex = i + window, Value = val });
                result[i] = queue[0].Value;
            }
            return result;
        }
    }
