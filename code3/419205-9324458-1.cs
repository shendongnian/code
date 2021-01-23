    public override string ToString()
    {
        string[] elements = new string[] { description, 
                    String.Concat(month, day, year),
                    amount.ToString("C"), paymentMethod, trip, note };
        return String.Join(", ", elements.Where(s => !String.IsNullOrWhiteSpace(s)));
    }
