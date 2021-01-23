       ............
          
          public string Name
        {
            get{
                return _name;
            }
            set{
                _name = WindowsIdentity.GetCurrent().Name.Split('\\')[1];
            }
