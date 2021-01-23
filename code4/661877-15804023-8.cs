		abstract class A {
			public abstract void Metod1();
		}
		class B: A {
			public override void Metod1() { // use `new` instead of `override` would not compile
				Console.WriteLine("B.Method1");
			}
		}
