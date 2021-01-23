	public partial interface IColor<T> {
		IColor<U> FromColor<U>(IColor<U> color);
	}
	// specify desired IColor<T> with the class
	public partial class Bgr: IColor<byte>, IColor<int> {
		public IColor<T> FromColor<T>(IColor<T> color) {
			if(null==color)
				// pass null to get the instance of real type
				return Bgr.Structure<T>.Empty;
			else {
				if(color is Bgr) {
					var bgr=(Bgr)color;
					return new Bgr.Structure<T> {
						B=(T)bgr.B,
						G=(T)bgr.G,
						R=(T)bgr.R
					};
				}
				else {
					if(color is Bgr.Structure<T>) {
						var value=(Bgr.Structure<T>)color;
						return new Bgr {
							B=value.B,
							G=value.G,
							R=value.R
						} as IColor<T>;
					}
					else {
						// conversion from other color types
						throw new NotImplementedException();
					}
				}
			}
		}
		// each color type would have its own Structure<T>
		// e.g.: if you have a `Hsl` class, declare Structure<T> inside it
		public partial struct Structure<T>: IColor<T> {
			public IColor<U> FromColor<U>(IColor<U> color) {
				// make the structure meet the constraint of IColor<T>
				// generally not invoked
				throw new NotImplementedException();
			}
			public T B, G, R;
			public static readonly Structure<T> Empty;
		}
		// the fields must be as Structure<T>
		public object B, G, R;
	}
	// add `where T: struct` if needed
	public partial class Image<TColor, T> where TColor: IColor<T>, new() {
		public static Array CreateRawData(params int[] lengths) {
			var color=(new TColor()).FromColor(default(TColor));
			return Array.CreateInstance(color.GetType(), lengths);
		}
		public Image(params int[] lengths) {
			// a sample instance of TColor
			m_Color=new TColor();
			// create raw data on construction
			m_Data=Image<TColor, T>.CreateRawData(lengths);
		}
		public Image(int x, int y)
			: this(new[] { x, y }) {
		}
		public TColor this[params int[] indices] {
			set {
				m_Data.SetValue(m_Color.FromColor(value), indices);
			}
			get {
				var value=m_Data.GetValue(indices) as IColor<T>;
				return (TColor)m_Color.FromColor(value);
			}
		}
		TColor m_Color;
		Array m_Data;
	}
