    public class ConnectBToADto
    {
        public Guid AId { get; set; }
        public Guid BId { get; set; }
    }
    public void ConnectBToA(ConnectBToADto dto)
    {
        var b = new B() { Id = dto.BId };
        Context.B.Attach(b);
		//Add a new A if the relation does not exist. Redundant if you now that both AId and BId exists		
        var a = Context.A.SingleOrDefault(x => x.Id == dto.AId);
        if(a == null)
        {
            a = new A() { Id = dto.AId };
            Context.A.Add(a);
        }
        b.As.Add(a);
    }
