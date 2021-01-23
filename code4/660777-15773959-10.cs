    private void swapData(int i, int j)
    {
        int nMax = Math.Max(i, j);
        int nMin = Math.Min(i, j);
        DataLine tempMax = Data[nMax];
        DataLine tempMin = Data[nMin];
        Action swap = () =>
        {
            Data.RemoveAt(nMax);
            Data.RemoveAt(nMin);
            Data.Insert(nMin, tempMax);
            Data.Insert(nMax, tempMin);
        };
        Dispatcher.Invoke(swap, null);
    }
