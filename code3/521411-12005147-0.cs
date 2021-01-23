     string directory = Server.MapPath("~/DesktopModules/SMSFunction/SMSText");
     string filename = String.Format("{0:yyyy-MM-dd}__{1}.txt", DateTime.Now, name);
     string path = Path.Combine(directory, filename);
        if (!File.Exists(path))
        {
            using (StreamWriter str = File.CreateText(path))
            {
                str.WriteLine("msisdn: " + source);
                str.WriteLine("shortcode : " + dest);
                str.WriteLine("Message : " + messageIn);
                str.WriteLine("Operator :" + operatorNew);
                str.Flush();
            }
        }
        else if (File.Exists(path))
        {
            using (var str = new StreamWriter(path))
            {
                str.WriteLine("msisdn: " + source);
                str.WriteLine("shortcode : " + dest);
                str.WriteLine("Message : " + messageIn);
                str.WriteLine("Operator :" + operatorNew);
                str.Flush();
         }
     
