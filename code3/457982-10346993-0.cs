    public void main()
    {
        var c = new Contact("europeroad",9999, "USA");
    }
    public Contact(string address, int zipcode, string country){
        this.Address = new Address(address,zipcode,country);
    }
