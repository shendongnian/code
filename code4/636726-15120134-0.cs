		public class ConcreteClass : IFlexibility1, IFlexibility2
		{
			void IFlexibility1.Method()
			{
				Trace.WriteLine("CC");
			}
			void IFlexibility2.Method()
			{
			}
		}
		public class Impl2 : ConcreteClass, IFlexibility1
		{
			void IFlexibility1.Method()
			{
				Trace.WriteLine("I2");
			}
		}
