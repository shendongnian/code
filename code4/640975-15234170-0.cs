		using System.Collections.Generic;
		using System.Collections;
		using System;
		public partial class Permutable<T>: IEnumerable {
			public static explicit operator Permutable<T>(T[] array) {
				return new Permutable<T>(array);
			}
			static IEnumerable Permute<TElement>(IList<TElement> list, int depth, int count) {
				if(count==depth)
					yield return list;
				else {
					for(var i=depth; i<=count; ++i) {
						Swap(list, depth, i);
						foreach(var sequence in Permutable<T>.Permute(list, 1+depth, count))
							yield return sequence;
						Swap(list, depth, i);
					}
				}
			}
			static void Swap<TElement>(IList<TElement> list, int depth, int index) {
				var local=list[depth];
				list[depth]=list[index];
				list[index]=local;
			}
			IEnumerator IEnumerable.GetEnumerator() {
				return this.GetEnumerator();
			}
			public IEnumerator<IList<T>> GetEnumerator() {
				var list=this.m_List;
				if(list.Count>0)
					foreach(IList<T> sequence in Permutable<T>.Permute(list, 0, list.Count-1))
						yield return sequence;
			}
			protected Permutable(IList<T> list) {
				this.m_List=list;
			}
			IList<T> m_List;
		}
