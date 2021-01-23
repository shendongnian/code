	public class CarDictionary : List<Car>
	{
		public Car this[string name]
		{
			get { return this.Single(car => car.Name.Equals(name)); }
			set {
				var oldCar = this.SingleOrDefault(car => car.Name.Equals(name));
				if (oldCar != null) base.Remove(oldCar);
				value.Name = name;
				base.Add(value);
			}
		}
		
		public new void Add(Car car)
		{
			if (this.Any(c => c.Name.Equals(car.Name))) 
				throw new InvalidOperationException("Dictionary already contains a Car with the same name");
			base.Add(car);
		}
	}
