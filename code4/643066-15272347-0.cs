    var a = new[] { 1f, 2f, 3f };
    var b = new[] { 1f, 2f, 3f };
	
    var hashA=((IStructuralEquatable)a).GetHashCode(EqualityComparer<float>.Default);
    var hashB=((IStructuralEquatable)b).GetHashCode(EqualityComparer<float>.Default);
    Console.WriteLine(hashA == hashB); // true
