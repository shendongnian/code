    public class Car {
    
        public string Name {get;set}
        public string ID {get;set;}
        public string CAR {get;set;}
    
        public Car(string name,string id,string car){
            Name = name;
            ID = id;
            CAR = car;
        }
    
        public override string ToString(){
            return string.format("Name: {0}, ID: {1}, CAR: {2}",Name,ID,CAR);
        }
    }
