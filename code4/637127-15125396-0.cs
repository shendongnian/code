    var query =
         // for each <Output> thingy...
         from outputThing in sourceOutputs
         // group them by Tree ID (option 1)
         group outputThing by 
             new { ID = outputThing.TreeID, Name = outputThing.TreeName } 
         into byTree
         // So now we can transform these groups of <Output> into a tree
         select new Tree
         {
             ID = byTree.Key.ID,
             Name = byTree.Key.Name,
             // And now the sub objects:
             // what 'byTree' actually is => a key (ID + name), 
             // and an enumerable of <Output> objects that match that key
             SubObjects = 
               (
                   from matchedThingy in byTree
                   select new SubObject() 
                   { 
                       Level = matchedThingy.SubObjectLevel,
                       Name = matchedThingy.SubObjectName
                    }
               ).ToList()
         };
