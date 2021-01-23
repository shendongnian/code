    public class Car
    {
         int year;
         bool manual;
    }
    
    public class Porsche : Car
    {
        bool specialPorscheOnlyFeature;
        Engine enginge;
    }
    
    public class Engine
    {
       string engineType;
    } 
    // in some method
    
    Porsche p = new Porsche();
    // to get Car data
    int yearOfCar = p.year; 
    bool isManual = p.manual;
    bool specialFeature = p.SpecialPorscheOnlyFeature;
