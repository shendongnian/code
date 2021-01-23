    Dictionary<int, List<Client>> SuplierClients = new Dictionary<int, List<string>>();
            foreach (KeyValuePair<int, List<Client>> suplierClient in SuplierClients)
            {
                // your supplier id, could even replace it with a Supplier Object.
                Console.WriteLine(suplierClient.Key);
                Console.WriteLine(suplierClient.Value.ToString());
            }
