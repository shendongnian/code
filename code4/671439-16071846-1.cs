    [Route("/clients", "GET")]
    public class AllClients : IReturn<List<Client>> {}
    [Route("/clients/{Id}", "GET")]
    public class GetClient : IReturn<Client>
    {
        public string Id { get; set; }
    }
