     var currentRoot = null;
     var rootObjects = new List<RootObject>();
     while (rdr.Read()){
            string name= rdr.GetValue(0).ToString();
            string serial = rdr.GetValue(1).ToString();
            string bz = rdr.GetValue(2).ToString(); <-- made this up
            if( currentRoot == null || currentRoot.name != name )
            {
                if( currentRoot != null ){
                   rootObjects.Add(currentRoot);
                }
                currentRoot = new RootObject();
                currentRoot.name = name;
            }
            currentRoot.serials.Add(new Serial(){zone = bz});
 
            ... instantiate other classes
        }
        rdr.Close();
     foreach( var rootObj in rootObjects) doSomethingWithRootObj(rootObj);
