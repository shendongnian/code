        List<string> Links = new List<string>();
        string line = null;
        using (StreamReader reader = new StreamReader(PathToYourFile))
        {
            while ((line = reader.ReadLine()) != null)
            {
                Links.Add(string.Format("http://website.com/q='{0}'", line);
            }
        }
