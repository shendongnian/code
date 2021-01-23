        public static void ArrayRotate(Array data, int index)
        {
            if (index > data.Length)
                throw new ArgumentException("Invalid index");
            else if (index == data.Length || index == 0)
                return;
            var copy = (Array)data.Clone();
            int part1Length = data.Length - index;
            //Part1
            Array.Copy(copy, 0, data, index, part1Length);
            //Part2
            Array.Copy(copy, part1Length, data, 0, index);
        }
