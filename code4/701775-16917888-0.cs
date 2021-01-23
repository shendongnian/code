    public IEnumerable Update()
    {
        while (true)
        {
            ShootAtPlayer();
            yield return Wait(30);
        }
    }
    
    private int Wait(int x)
    {
        return removeScript ? -1 : x;
    }
