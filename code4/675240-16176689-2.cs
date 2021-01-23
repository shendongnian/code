    public int DaysEmployed
    {
        get
        {
            int returnValue = 0;
                returnValue = Convert.ToInt32 (DateTime.Now.Subtract(this.HireDate).TotalDays);
            return returnValue;
        }
    }
