    stirng ip1= "1.2.3.4";
    string ip2 ="5.6.7.8";
    
    string ip1R = ip1.Replace(".");
    string ip2R = ip2.Replace(".");
    
    Console.WriteLine(String.Compare(ip1R ,ip2R ));
----------
    You can do soem thing like this 
    
    stirng ip1= "1.2.3.4";
    string ip2 ="5.6.7.8";
    
    long ip1 = ip1.Replace(".");
    long ip2 = ip2.Replace(".");
    
    if(ip1==ip2)
    {
    }
    if(ip1>ip2)
    {
    }
    if(ip2>ip1)
    {
    }
