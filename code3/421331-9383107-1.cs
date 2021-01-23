    public IComparable GetKey(int keyNum)
    {
        switch (keyNum) {
            case 1:
                return Name;
            case 2:
                return CreationTime;
            default:
                return null;
        }
    }
