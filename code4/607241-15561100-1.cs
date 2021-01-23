	By the way, thanks to a runtime trick every array `T[]` **does implement** [IEnumerable&lt;T&gt;], [ICollection&lt;T&gt;] and [IList&lt;T&gt;] automatically. 
	From the documentation of [Array Class][Array]: 
	* Important
		>Starting with the .NET Framework 2.0, the Array class implements the [System.Collections.Generic.IList&lt;T&gt;][IList&lt;T&gt;], [System.Collections.Generic.ICollection&lt;T&gt;][ICollection&lt;T&gt;], and [System.Collections.Generic.IEnumerable&lt;T&gt;][IEnumerable&lt;T&gt;] generic interfaces. The implementations are provided to arrays at run time, and therefore are not visible to the documentation build tools. As a result, the generic interfaces do not appear in the declaration syntax for the Array class, and there are no reference topics for interface members that are accessible only by casting an array to the generic interface type (explicit interface implementations). **The key thing** to be aware of when you cast an array to one of these interfaces is that members which add, insert, or remove elements throw [NotSupportedException]. 
	That's because, for example, [ICollection&lt;T&gt;] has an [Add] method, but you cannot add anything to an array. It will throw an exception. This is another example of an early design error in the .NET Framework that will get you exceptions thrown at you at run-time. 
		ICollection<Mammoth> collection = new Mammoth[10]; // Cast to interface type
		collection.Add(new Mammoth());                     // Run-time exception
	And since [ICollection&lt;T&gt;] is not covariant(for obvious reasons), you can't do this as following code. 
		ICollection<Mammoth> mammoths = new Array<Mammoth>(10);
		ICollection<Animal> animals = mammoths; // Not allowed
	Of course there is now the covariant interface [IReadOnlyCollection&lt;T&gt;] that is also implemented by arrays under the hood, but it contains only `Count` so its usefulness is very limited. 
