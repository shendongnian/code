    //
    // Patch for Bug in IQ-Driver
    //
    // If each nullable long field which is null ist set to 0L
    // DeleteOnSubmit() works!!
    //
    public static void PatchForDelete(object entity) {
        var fields = entity.GetType().GetFields();
    
        foreach (var field in fields) {
            if (field.FieldType == typeof(long?)) {
                var v = field.GetValue(entity);				
                if (v == null) {
                    field.SetValue(entity, 0L);
                }
            }
        }
    }
