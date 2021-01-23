	public partial interface IColor<T> where T: struct {
		T B {
			get;
			set;
		}
		T G {
			get;
			set;
		}
		T R {
			get;
			set;
		}
	}
	public partial struct BGR: IColor<ValueType> {
		public ValueType B {
			get;
			set;
		}
		public ValueType G {
			get;
			set;
		}
		public ValueType R {
			get;
			set;
		}
	}
	public partial class Image<TColor, T>
		where TColor: IColor<ValueType>
		where T: struct {
		public IColor<T>[,] data;
	}
