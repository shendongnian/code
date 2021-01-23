     public sealed class Car  : IEquatable<Car> { 
	 // declare and define each of your constants
	    public static readonly Car carA = new Car("ford", "red");
	    public static readonly Car carB = new Car("bmw", "black");
	    public static readonly Car carC = new Car("toyota", "white");
	 //  define an instance-scoped value object to hold your subObjects
	     private readonly Tuple<string,string> subObjects;
	 // a private constructor ensures that all your instances will be constant 
	 // and will be defined from within Car
	     private Car(string make, string color){
		 // require valid sub objects
		 if(string.IsNullOrEmpty(make))throw new ArgumentException("Invalid Make","make");
		 if(string.IsNullOrEmpty(color))throw new ArgumentException("Invalid Color","color");
		 // create a subObjects tuple to hold your values to simplify value comparison
		 this.subObjects = Tuple.Create(make,color);
	     }
	 //  declare public accessors for your 
	     public string Make { get { return this.subObjects.Item1; } }
	     public string Color { get { return this.subObjects.Item2; } }
	 // override Equality for value equality, and resulting consistency across AppDomains
    	     public override bool Equals(object obj){ return obj is Car && this.Equals((Car)obj); }
	     public bool Equals(Car otherCar){ return otherCar != null && this.subObjects.Equals(otherCar.subObjects); }
	     public override int GetHashCode(){ return this.subObjects.GetHashCode(); }
             public static bool operator ==(Car left, Car right){ return left == null ? right == null : left.Equals(right); }
             public static bool operator !=(Car left, Car right){ return !(left == right); }
	 // override ToString() to provide view of values 
	     public override string ToString(){ return string.Format("Car({0},{1})",Make,Color); }
    }
