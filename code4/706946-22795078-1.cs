    private DateTime? registered;
    [Required]
    public DateTime Registered
    {
        get
        {
            if (registered == null)
            {
                registered = DateTime.Now;
            }
            return registered.Value;
        }
        private set { registered = value; }
    }
