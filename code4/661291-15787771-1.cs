    var Computer = new ComputerEntity();
    var Motherboard = new MotherboardEntity();
    Computer.Motherboard = Motherboard;
    DbSet<ComputerEntity>.Add(Computer);
    DbContext.SaveChanges();
