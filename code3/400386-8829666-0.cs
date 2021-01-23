    private bool isPerishable;
    public bool IsPerishable
    {
        get { return isPerishable; }
        set
        {
          isPerishable = value;
          if(value && expiryDate == default(DateTime))
          {
            Console.Write("Enter an expiry date: ");
            expiryDate = Date.Parse(Console.ReadLine());
          }          
        }
    }
