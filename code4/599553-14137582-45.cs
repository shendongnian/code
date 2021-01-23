		public interface IBase {}
		public interface ISomething {}
		public interface IDerivied: IBase {}
		public interface IDeriviedRight: IDerivied {}
		public interface IDeriviedLeft: IDerivied, IDisposable {}
		public class AnotherDisposable: IDisposable {
			public void Dispose() {
			}
		}
		public class DeriviedLeft: IDeriviedLeft {
			public void Dispose() {
			}
		}
		public class SubDeriviedLeft: DeriviedLeft {}
		public class SecondSubDeriviedLeft: DeriviedLeft {}
		public class ThirdSubDeriviedLeft: DeriviedLeft, ISomething {}
		public class Another {}
		public class DeriviedRight: IDeriviedRight {}
