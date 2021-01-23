    public void UpdateStuff()
    {
        ClassA[] CAArray = new ClassA[large_number];
        Double Value = CAArray.Select(x => x.ClassB.Value * x.Multiplier).Sum();
    }
