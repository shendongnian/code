    [global::System.Data.Linq.Mapping.AssociationAttribute(Name="AssociationName", Storage="_User", ThisKey="UserId", OtherKey="Id", IsForeignKey=true)]
    [global::System.Runtime.Serialization.DataMemberAttribute(Order=7, EmitDefaultValue=false)]
    public User User
    {
    	get
    	{
    		if ((this.serializing 
    					&& (this._User.HasLoadedOrAssignedValue == false)))
    		{
    			return null;
    		}
    		return this._User.Entity;
    	}
    	set
    	{
    		if ((this._User.Entity != value))
    		{
    			this.SendPropertyChanging();
    			this._User.Entity = value;
    			this.SendPropertyChanged("User");
    		}
    	}
    }
