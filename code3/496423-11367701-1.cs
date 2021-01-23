    [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NText", UpdateCheck=UpdateCheck.Never)]
    		public string Description
    		{
    			get
    			{
    				return this._Description;
    			}
    			set
    			{
    				if ((this._Description != value))
    				{
    					this.OnDescriptionChanging(value);
    					this.SendPropertyChanging();
    					this._Description = value;
    					this.SendPropertyChanged("Description");
    					this.OnDescriptionChanged();
    				}
    			}
    		}
