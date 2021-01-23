	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	public partial class AnyStepComparer<T>: IComparer<T> {
		int IComparer<T>.Compare(T stepX, T stepY) {
			if(typeof(Step)==typeof(T)||typeof(AutoStep)==typeof(T))
				return (
					from it in new[] { 0 }
					let type=typeof(T)
					let flagsAccess=BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public
					let invokeAttr=flagsAccess|BindingFlags.GetProperty|BindingFlags.GetField
					let binder=default(Binder)
					let args=default(object[])
					let x=(int)type.InvokeMember("StepNumber", invokeAttr, binder, stepX, args)
					let y=(int)type.InvokeMember("StepNumber", invokeAttr, binder, stepY, args)
					select Comparer<int>.Default.Compare(x, y)
					).First();
			var message="{0} must be either Step or AutoStep";
			var paramName="[T]";
			throw new ArgumentException(String.Format(message, paramName), paramName);
		}
		public static readonly AnyStepComparer<T> Default=new AnyStepComparer<T>();
	}
