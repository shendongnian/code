    public static MyClass BuildFirst()
    {
        return entities.someTable
                       .First()
                       .Select(f => new MyClass(){
                            PropertyONE = f.PropertyONE,
                            PropertyTWO = f.PropertyTWO
                       });
    }
