    // Get Public IP
    			var ip = IPK.GetMyPublicIp();
    
    			//Get all IP infos
    			var IPinfo = IPK.GetIpInfo(ip);
    
    			//print some info
    			Console.WriteLine("*--------------------------- IPK -----------------------------*");
    
    			Console.WriteLine("My public IP : " + IPinfo.IP);
    			Console.WriteLine();
    			Console.WriteLine("My ISP : " + IPinfo.isp);
    			Console.WriteLine();
    			Console.WriteLine("My Country : " + IPinfo.country);
    			Console.WriteLine();
    			Console.WriteLine("My Languages : ");
    
    			foreach (var lang in IPinfo.languages)
    			{
    				Console.WriteLine(" " + lang.Key + " : " + lang.Value);
    			}
    
    			Console.WriteLine("*-------------------------------------------------------------*");
    			Console.Read();
