	class Address {
		public string Street { get; set; }
	}
	class User {
		public List<Address> Addresses = new List<Address>();
	}
	class FeatureX {
		public void UpdateUserWithAddress(User user, Address address) {
			if (user.Addresses.Count > 0) {
				user.Addresses[0] = address;
			} else {
				user.Addresses.Add(address);
			}
		}
	}
