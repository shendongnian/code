    public IEnumerable<int> F2()
    {
        for (int i = 0; i < 10; i++) {
            yield return i;
        }
    }
    public IEnumerable<int> F1()
    {
        return F2();
    }
