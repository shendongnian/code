    public int CompareTo(Employee other)
    {
        int result = string.Compare(this.Name, other.Name);
        Debug.WriteLine("Result of Compare of {0} and {1} is {2}", 
            this.Name, other.Name, result);
        return result;
    }
