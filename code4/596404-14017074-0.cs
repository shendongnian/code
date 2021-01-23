    public static void Deduplicate(this List<float> values, float delta, int decimals)
    {
        int index = 0;
        while (index < values.Count)
        {
            float value = values[index];
            int i = index + 1;
            while (i < values.Count)
            {
                if (Math.Round(Math.Abs(value - values[i]), decimals) < delta)
                    values.RemoveAt(i);
                else
                    ++i;
            }
            ++index;
        }
    }
