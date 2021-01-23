	1. The [GetInterfaces](http://msdn.microsoft.com/en-us/library/system.type.getinterfaces.aspx) method does not return interfaces in a particular order, such as alphabetical or declaration order. Your code must not depend on the order in which interfaces are returned, because that order varies. 
	2. Because of recursion, base classes are **always ordered**. 
	3. If two interfaces of the top have the same coverage, **is nothing different from there's none**. 
		Suppose we have these interfaces defined(or classes are just fine): 
			public interface IDelta {
			}
			public interface ICharlie {
			}
			public interface IBravo: IDelta, ICharlie {
			}
			public interface IAlpha: IDelta, ICharlie {
			}
		Then which one is better for assignment between `IAlpha` and `IBravo`? 
		I would say **none**! 
		Isn't it simple and clear? In this case, `FindInterfaceWith` just returns `null`. 
