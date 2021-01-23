	class DoubleDown: IGeneric<Derived1>, IGeneric<Derived2> {
		string IGeneric<Derived1>.GetName() {
			return "Derived1";
		}
		string IGeneric<Derived2>.GetName() {
			return "Derived2";
		}
	}
	class DoubleDown: IGeneric<Derived2>, IGeneric<Derived1> {
		string IGeneric<Derived1>.GetName() {
			return "Derived1";
		}
		string IGeneric<Derived2>.GetName() {
			return "Derived2";
		}
	}
