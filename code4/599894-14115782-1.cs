    // Our anonymous type sequence
    var anonymousEnumerable = Enumerable
            .Range(0, 10)
            .Select(i => new { ID = i, Text = i.ToString() });
	var enumerableCount = anonymousEnumerable.Count();
	var anonymousType = anonymousEnumerable.First().GetType();
	
    // Option #1 - declare it as dynamic, i.e., anything goes
    dynamic[] asDynamicArray = new dynamic[enumerableCount];
	foreach(var tuple in anonymousEnumerable.Select((item, i) => Tuple.Create(i, item)))
	{
		asDynamicArray[tuple.Item1] = tuple.Item2;
	}
	// Let's go the IEnumerable route
	foreach (var asDynamic in asDynamicArray)
	{
		Console.WriteLine("ID:{0} Text:{1}", asDynamic.ID, asDynamic.Text);
	}
	
    // Lowest common denominator: *everything* is an object
    object[] asObjectArray = new object[enumerableCount];
	foreach(var tuple in anonymousEnumerable.Select((item, i) => Tuple.Create(i, item)))
	{
		asObjectArray[tuple.Item1] = tuple.Item2;
	}
	// Let's iterate with a for loop - BUT, it's now "untyped", so things get nasty
	var idGetterMethod = anonymousType.GetMethod("get_ID");
	var textGetterMethod = anonymousType.GetMethod("get_Text");
	for(int i=0;i < asObjectArray.Length; i++)
	{
		var asObject = asObjectArray[i];
		var id = (int)idGetterMethod.Invoke(asObject, null);
		var text = (string)textGetterMethod.Invoke(asObject, null);
		Console.WriteLine("ID:{0} Text:{1}", id, text);
	}
    // This is cheating :)
    var letTheCompilerDecide = anonymousEnumerable.ToArray();
	foreach (var item in letTheCompilerDecide)
	{
		Console.WriteLine("ID:{0} Text:{1}", item.ID, item.Text);
	}
    // Use reflection to "make" an array of the anonymous type
    var anonymousArrayType = anonymousType.MakeArrayType();
    var reflectIt = Activator.CreateInstance(
              anonymousArrayType, 
              enumerableCount) as Array;	
	Array.Copy(anonymousEnumerable.ToArray(), reflectIt, enumerableCount);	
		  
	// We're kind of in the same boat as the object array here, since we
	// don't really know what the underlying item type is
	for(int i=0;i < reflectIt.Length; i++)
	{
		var asObject = reflectIt.GetValue(i);
		var id = (int)idGetterMethod.Invoke(asObject, null);
		var text = (string)textGetterMethod.Invoke(asObject, null);
		Console.WriteLine("ID:{0} Text:{1}", id, text);
	}
