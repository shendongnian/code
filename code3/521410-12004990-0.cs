    public void WriteToFile(string name, string source, int dest, string messageIn, string operatorNew)
    {
        string directory = ResolveUrl("~/DesktopModules/SMSFunction/SMSText");
        string filename = String.Format("{0:yyyy-MM-dd}__{1}", DateTime.Now,name);
        string path = Path.Combine(directory, filename);
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter str = new StreamWriter(fs))
            {
                str.WriteLine("msisdn: " + source);
                str.WriteLine("shortcode : " + dest);
                str.WriteLine("Message : " + messageIn);
                str.WriteLine("Operator :" + operatorNew);
                str.Flush();
            }
        }
    }
