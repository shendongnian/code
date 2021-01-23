    [System.Serializeable]
    public Struct SomeclassData(){  
   
    Vector3 vec;
    float value;
    // some numeric data or vector data  }
    
    public class SomeClass : Monobehaviour{
    SomeclassData data;
     
    void Start(){
     data = new SomeClassData();
    }
    }
 
