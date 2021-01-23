		class A {
			public virtual void Metod1() {
				Console.WriteLine("A.Method1");
			}
		}
		class B: A {
			public override void Metod1() {
				Console.WriteLine("B.Method1");
			}
		}
