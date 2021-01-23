    void SetTime(int time, int num)
    {
        if (!hashSet.Contains(num))
            {
                theTime = time;
                hashSet.Add(num);
            }
    }
