    // this variable will be declared in your class .
    
    public static string devicename;
    
    CFManzana.iDevice
    phone = New iDevice();
    phone.connect += phone_connect;
    
    void phone_connect(object sender, ConnectEventArgs args)
            {
    // here your will add your exception handling details.
               }
    
    // now extract your device details.
    
    devicename = phone.getDeviceName or phone.CopyValue("DeviceName"); \\it all depends what version of Manzana you have downloaded.
    
    //now assign the value to the field 
    
    this.txtname.text = devicename;
-------------------------------------------------
