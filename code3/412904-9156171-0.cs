    public String FirstName_for_display {
        get {
            if(FirstName == null || FirstName[0] == null)
                return "";
            return FirstName[0].Value;
        }
    }
