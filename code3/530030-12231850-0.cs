     List<string> lines = new List<string>();
     StreamReader reader = new StreamReader(WebRequest.Create("http://cyprus.angloinfo.com/").GetResponse().GetResponseStream());
      string line;
      while ((line = reader.ReadLine()) != null)
      {
          lines.Add(line);
      }
      label1.Text = String.Join(" ", lines.ToArray());
