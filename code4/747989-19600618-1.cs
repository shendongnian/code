    public class PrecedesData
    {
        public string Name { get; set; }
        public bool IsOptional { get; set; }
    }
    client.Cypher
        .Start(new { prevProcess, currProcess })
        .CreateUnique("prevProcess-[:PRECEDES {precedes}]->currProcess")
        .WithParams(new { precedes = new PrecedesData { Name = product, IsOptional = isOptional } })
        .ExecuteWithoutResults();
