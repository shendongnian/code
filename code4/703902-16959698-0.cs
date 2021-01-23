	public partial class PersonCollection: List<Person> {
		public object[] GetValues(String propertyName) {
			return (
				from it in this
				let x=
					"Name"==propertyName
						?it.Name
						:"Property1"==propertyName
							?it.Property1
							:"Property2"==propertyName
								?it.Property2
								:default(object)
				where null!=x
				select x).ToArray();
		}
	}
