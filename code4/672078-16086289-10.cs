		partial class Image<TColor, T> {
			public Image(params int[] lengths) {
				// a sample instance of TColor
				m_Color=new TColor();
				// create raw data on construction
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
						indices=indices.Transform(m_Data);
						var value=m_Data.GetValue(indices) as IColor<T>;
						var color=m_Color.FromColor(value);
						return (TColor)color;
					}
				}
			}
			TColor m_Color;
			Array m_Data;
		}
		public static partial class ArrayExtensions {
			public static int[] Transform(this int[] indices, Array array) {
				if(indices.Length>array.Rank)
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
	Here are something to mention for the extended code: 
	1. As the implementation, you can either declare an `Image` like 
			var image=new Image<Bgr, int>(320, 240);
		or 
			var image=new Image<Bgr.Structure<byte>, byte>(320, 240);
		If you declare with `Bgr.Structure<byte>`, then assignment from another type like `Bgr.Structure<int>` is not allowed. 
		If you declare with `Bgr, int`, and do the following: 
			var image=new Image<Bgr, int>(320, 240);
			image[0, 0]=(Bgr)Bgr.Default.FromColor(new Bgr.Structure<long>());
		then the `Bgr.Structure<long>` will be cast by current implementation, and you can change the code of `Bgr.FromColor` to disallow. 
	2. Note that though you can set new value to the elements through the indexer, you would not be able to change the properties or fields of the elements directly, such as `image[0, 0].B=123`; it is just a copy. 
	3. `ArrayExtensions.Transform` performs a linear transformation for the indices with the geometry of a specified array. However, if the length of indices is more than the given array, it does nothing but returns original, because we would have no idea to transform the indices from a higher dimension of an unknown geometry(and `Array` itself will throw). 
	4. `IColor<T>` doesn't constraint the color types to implement particular properties, so the color types are free to implement on their own. Nevertheless, I'd suggest that it derives from `IComparable<IColor<T>>`, `IEquatable<IColor<T>>` for the convenience of use, and also some kind of a readonly `IEnumerable` for listing on the color types' fields/properties. 
	5. Let me know if you have an idea of **what is an image has more dimensions than two** 
