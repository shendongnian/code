    public void StoreCredentials(Credentials credentials)
        {
            credentials.Encrypt(_myUser.Encryption);
            Hashtable credsTable;
            var soap = new SoapFormatter();
            FileStream stream;
            try
            {
                stream = new FileStream(_path, FileMode.Open, FileAccess.ReadWrite);
                credsTable = (Hashtable) soap.Deserialize(stream);
                stream.Close();
                stream = new FileStream(_path, FileMode.Create, FileAccess.ReadWrite);
                if (credsTable.ContainsKey(credentials.Id))
                    credsTable[credentials.Id] = credentials;
                else
                    credsTable.Add(credentials.Id, credentials);
            }
            catch (FileNotFoundException e)
            {
                stream = new FileStream(_path, FileMode.Create, FileAccess.ReadWrite);
                credsTable = new Hashtable {{credentials.Id, credentials}};
            }
            soap.Serialize(stream, credsTable);
            stream.Close();
        }
