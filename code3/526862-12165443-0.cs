    public class AModel { 
        DateTime DateFrom { get;set; } 
        DateTime DateThru { get;set; } 
    }   
    public class BModel { 
        ModelDateCollection DateFrom { get;set; } 
        ModelDateCollection DateThru { get;set; } 
    }   
    public class ModelDateCollection { 
        DateTime Date { get;set; } 
        String Display { get; } // Example Readonly for Date Display 
        DateTime FirstOfMonth { get; } // Another Example to extend Complex Class 
    } 
