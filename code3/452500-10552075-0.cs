	    public string DateOfBirthString
	    {
            get { return DateOfBirth.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"); }
            set { DateOfBirth = string.IsNullOrEmpty(value) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(value); }
	    }
