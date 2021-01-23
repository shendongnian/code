    List<string[]> results = new List<string[]>();
    ....
    while ((line = file.ReadLine()) != null) {
      if (line.Contains(cword)) {
        results.Add(fnList[i]);
        break; // optional, if possible, but if you need to continue check for dupes
      }
    }
    ....
    return Json(new { 
      success = true, 
      fnList = results.ToArray(),
      arrayList = arrayList.ToArray(), 
      stateList = stateList.ToArray() 
    });
