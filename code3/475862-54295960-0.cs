               StreamReader sr = new StreamReader(filePath);
               while ((line = sr.ReadLine()) != null)
               {
                    //Console.WriteLine(line);
                    string[] csv = line.Split(',');
                    var dictionary = new Dictionary<string, string>();
                    dictionary.Add("dispatching_base_number",csv[0]);
                    dictionary.Add("available_vehicles", csv[1]);
                    dictionary.Add("vehicles_in_trips", csv[2]);
                    dictionary.Add("Cancellations", csv[3]);
                    string jsonN = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dictionary);
                    Console.WriteLine("Sending message: {0}",jsonN);
}
