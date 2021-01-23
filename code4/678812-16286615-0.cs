    using System;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;
    
    class App
    {
      static void Main()
      {
        var data = new byte[] { 1,2,3,4 };
        var mac1 = new PhysicalAddress(data);
        var mac2 = new PhysicalAddress(data);
        var dictionary = new Dictionary<PhysicalAddress,string>();
        dictionary[mac1] = "A";
        Console.WriteLine("Has mac1:" + dictionary.ContainsKey(mac1));
        //Console.WriteLine("Has mac2:" + dictionary.ContainsKey(mac2));
        data[0] = 0;
        Console.WriteLine("After modification");
        Console.WriteLine("Has mac1:" + dictionary.ContainsKey(mac1));
        Console.WriteLine("Has mac2:" + dictionary.ContainsKey(mac2));
    
        dictionary[mac2] = "B";
        foreach (var kvp in dictionary)
          Console.WriteLine(kvp.Key + "=" + kvp.Value);
      }
    }
