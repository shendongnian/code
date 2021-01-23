	public class Person : IEntity<PersonKey>{
		public PersonKey Key {get;}
		public IEnumerable<Car> OwnedCars{
			get{
				CarRepository rep = DBSingletons.Cars;
				return rep.GetByOwner(this.Key);
			}
			set{
				//	do stuff
			}
		}
	}
