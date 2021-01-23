    [NotMapped]
    public Role Role { 
        get { return CustomerRole == null ? (Role)null : CustomerRole.Role; } 
        set { if (CustomerRole == null)
                CustomerRole = new CustomerRole(){ Role = value };
              else
                CustomerRole.Role = value;
        }
    }
