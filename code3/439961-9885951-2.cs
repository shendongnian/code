    public MyServiceProxyGateway : IStaffService
    {
        public Staff GetStaff()
        {
           var proxy = new YourProxyType();
           proxy.X = value;
           proxy.Y = value;
           var response = proxy.CallActualServiceMethod();
           Staff staff = new Staff();
           staff.Value = response.Something;
           return staff;
        }
    } 
