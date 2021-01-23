	public partial interface IColor<T> {
		// constrants class implements IColor<T> to tell 
		// how to convert from a color type to another(mostly itself)
		IColor<U> FromColor<U>(IColor<U> color);
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
			if(lengths.Length>0)
				m_Data=Image<TColor, T>.CreateRawData(lengths);
		}
		public Image(int width, int height)
			: this(new[] { width, height }) {
		}
		public TColor this[params int[] indices] {
			set {
				if(null!=m_Data) {
					var color=m_Color.FromColor(value);
					m_Data.SetValue(color, indices.Transform(m_Data));
				}
			}
			get {
				if(null==m_Data)
					return default(TColor);
				else {
					var value=
						m_Data.GetValue(indices.Transform(m_Data)) as IColor<T>;
					var color=m_Color.FromColor(value);
					return (TColor)color;
				}
			}
		}
		TColor m_Color;
		Array m_Data;
	}
	// specify desired IColor<T> with the class
	public partial class Bgr: IColor<byte>, IColor<int> {
		public IColor<T> FromColor<T>(IColor<T> color) {
			if(null==color)
				// pass null to get the instance of real type
				return default(Structure<T>);
			else {
				if(color is Bgr) {
					var bgr=(Bgr)color;
					// suggest to make IColor<T> implements IEquatable<SomeColor>
					if(null==bgr.B||null==bgr.G||null==bgr.R)
						return default(Structure<T>);
					else
						return new Structure<T> {
							B=(T)bgr.B,
							G=(T)bgr.G,
							R=(T)bgr.R
						};
				}
				else {
					if(color is Structure<T>) {
						var value=(Structure<T>)color;
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
				return color is Structure<T>?color:Bgr.Default.FromColor(color);
			}
			public T B, G, R;
		}
		public static readonly Bgr Default=new Bgr();
		// the fields must be as Structure<T>
		public object B, G, R;
	}
	public static partial class ArrayExtensions {
		public static int[] Transform(this int[] indices, Array array) {
			if(indices.Length>=array.Rank)
				return indices;
			else {
				var list=indices.ToList();
				for(int i=0, q=0, count=array.Rank; count-->0; ++i)
					if(indices.Length>i) {
						int r;
						q=Math.DivRem(indices[i]+q, array.GetLength(i), out r);
						list[i]=r;
					}
					else {
						list.Add(q);
						q=0;
					}
				return list.ToArray();
			}
		}
	}
