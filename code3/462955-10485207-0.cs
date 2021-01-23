    public string CalculateAge(DateTime birthDate)
    {
        using (var obj = new MyObject())
        {
            return obj.CalculateAge(birthDate);
        }
    }
