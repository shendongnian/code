	internal class agginit{internal static bool started=false;}
	public class agg<T>{
		//public static T add(T a,T b){return a+b;} // compile error: Operator '+' cannot be applied to operands of type 'T' and 'T'
		//public static T add(T a,T b){return (dynamic)a+b;} // compiles, but involves boxing and unboxing at run-time
		//public static int add(int a,int b){return a+b;} // won't be matched by test agg<T>.add(a,b) invokation
		public static T add(T a,T b){return _add(a,b);}
		static Func<T,T,T> _add=null;
		static agg(){
			if(!agginit.started){ // to prevent recursive actions
				agginit.started=true;
				agg<int>._add=(a,b)=>a+b;
				agg<double>._add=(a,b)=>a+b;
				// below we initialize all other potentially used additive types just for fun, if type is not listed here, it's not supported
				agg<string>._add=(a,b)=>a+b;
				agg<byte>._add=(a,b)=>{return (byte)(a+b);}; // dirty down-cast, needs to be enhanced with return type generic parameter
				agg<long>._add=(a,b)=>a+b;
				agg<System.Numerics.BigInteger>._add=(a,b)=>a+b;
				agg<StringBuilder>._add=(a,b)=>{var ret=new StringBuilder();ret.Append(a.ToString());ret.Append(b.ToString());return ret;};
				agg<IEnumerable<T>>._add=(a,b)=>a.Concat(b);
				agg<HashSet<T>>._add=(a,b)=>{var ret=new HashSet<T>(a);ret.UnionWith(b);return ret;};
				agg<SortedSet<T>>._add=(a,b)=>{var ret=new SortedSet<T>(a);ret.UnionWith(b);return ret;};
				agg<byte[]>._add=(a,b)=>{var ret=new byte[a.Length+b.Length];Buffer.BlockCopy(a,0,ret,0,a.Length);Buffer.BlockCopy(b,0,ret,a.Length,b.Length); return ret;};
				agg<System.IO.MemoryStream>._add=(a,b)=>{var ret=new System.IO.MemoryStream(new byte[a.Length+b.Length]);a.WriteTo(ret);b.WriteTo(ret);return ret;};
			}
		}
	}
