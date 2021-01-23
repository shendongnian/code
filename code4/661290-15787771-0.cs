    var FirstEntity = new DBEntity(); 
    var SecondEntity = new DBEntity();
    var ThirdEntity = new DBEntity();
    DbSet<DBEntity>.Add(SecondEntity);
    DbSet<DBEntity>.Add(ThirdEntity);
    SecondEntity.Sibling = FirstEntity;
