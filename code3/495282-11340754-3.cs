    public static class Equipments 
    {
        public static void AddEquipment(DBClassesDataContext db, string name, decimal dimLength)
        {
                Equipment equipment = new Equipment();
                equipment.Name = name;
                equipment.DimLength = dimLength;
    
                db.Equipments.InsertOnSubmit(equipment);
                db.SubmitChanges();
    
        }
    }
