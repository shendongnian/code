    string ip1= "1.2.3.4";
    string ip2 ="5.6.7.8";
    
    string ip1R = ip1.Replace(".","");
    string ip2R = ip2.Replace(".","");
    
    Console.WriteLine(String.Compare(ip1R ,ip2R ));
