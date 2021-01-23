    public int CountryInt{get;set;}
    public Countries Country
    		{
    			get { return (Countries) this.CountryInt; }
    			set { this.CountryInt = (int) value; }
    		}
