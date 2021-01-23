    public Task<List<Client>> GetClientListAsync()
    {
        return Task.Run(() =>
        {
            var list = new List<Client>
            {
                new Client { apellidos="Landeras", nombre="Carlos", edad=25 },
                new Client { apellidos="Lopez", nombre="Pepe", edad=22 },
                new Client { apellidos="Estevez", nombre="Alberto", edad=28 }
            };
            //Thread.Sleep to simulate some load
            System.Threading.Thread.Sleep(4000);
            return list;
        });
    }
