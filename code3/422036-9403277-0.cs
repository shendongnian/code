    for (i...){
        object oneObject = arrayList[i];
        Type objectType = oneObject.GetType();
        objectType.GetMethod("Draw").Invoke(oneObject, new object[0]);
    }
