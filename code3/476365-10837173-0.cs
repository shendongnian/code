        int[] _array = new int[] {1, 2, 1,2}
        var myArray = new System.Collections.ArrayList();
		foreach(var item in _array){
			if (!myArray.Contains(item))
				myArray.Add(item);
		}
