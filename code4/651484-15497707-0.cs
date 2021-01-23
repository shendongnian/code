    NameValueCollection values = ConfigurationManager.AppSettings;
    Iterate(values);
     
    public void Iterate(NameValueCollection myCollection)
     {
     IEnumerator myEnumerator = myCollection.GetEnumerator();
     Console.WriteLine(" KEY VALUE");
     foreach (String item in myCollection.AllKeys)
     Console.WriteLine(" {0,-10} {1}", item, myCollection[item]);
     Console.WriteLine();
     }
