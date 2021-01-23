	public static partial class TypeExtensions {
		public static Type[] GetTypesArray(this Type node) {
			if(null==node)
				return EmptyArray;
			else {
				var baseArray=TypeExtensions.GetTypesArray(node.BaseType);
				var interfaces=null==node?EmptyArray:node.GetInterfaces().Subtract(baseArray);
				var index=interfaces.Length+baseArray.Length;
				var typeArray=new Type[1+index];
				typeArray[index]=node;
				Array.Sort(interfaces, interfaces.CoverageComparison());
				Array.Copy(interfaces, 0, typeArray, index-interfaces.Length, interfaces.Length);
				Array.Copy(baseArray, typeArray, baseArray.Length);
				return typeArray;
			}
		}
		public static Type FindInterfaceWith(this Type type1, Type type2) {
			var array=type2.GetTypesArray().Intersect(type1.GetTypesArray());
			var typeCurrent=default(Type);
			for(var i=array.Length; i-->0; )
				if((null==(typeCurrent=array[i])||null==typeCurrent.BaseType)?i>0:false) {
					var typeNext=array[i-1];
					if(typeNext.FindInterfaceWith(typeCurrent)!=typeNext)
						return default(Type);
					else
						break;
				}
			return typeof(object)!=typeCurrent?typeCurrent:default(Type);
		}
		public static Type FindBaseClassWith(this Type type1, Type type2) {
			if(null==type1)
				return type2;
			if(null==type2)
				return type1;
			for(var currentType2=type2; null!=currentType2; currentType2=currentType2.BaseType)
				for(var currentType1=type1; null!=currentType1; currentType1=currentType1.BaseType)
					if(currentType2==currentType1)
						return currentType2;
			return default(Type);
		}
		public static Type FindEqualTypeWith(this Type type1, Type type2) {
			var baseClass=type2.FindBaseClassWith(type1);
			var interfaCe=type2.FindInterfaceWith(type1);
			if(null==interfaCe)
				return baseClass;
			else {
				if(null==baseClass||typeof(object)==baseClass||baseClass.IsAbstract)
					return interfaCe;
				else
					return baseClass;
			}
		}
	}
