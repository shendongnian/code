    var groups = from group in doc.Descendants("GROUP")
                where (string)group.Attribute("meetsMark") == "1"
                select group
    var subgroups = from subgroup in groups.Descendants("GROUP")
               where subgroup.Attribute("code").Value == "SECONDARY"
               select subgroup;
    
    foreach( var subgroup in subgroups )
    {
       System.Console.WriteFormat( "code = {0}", subgroup.Attribute("code").Value );
       var sums = from summary in subgroup.Descendants("SUMMARY")
    
       foreach( var sum in sums )
       {
           System.Console.WriteFormat( "sum = {0}", subgroup.Attribute("sum").Value );
           System.Console.WriteFormat( "number = {0}", subgroup.Attribute("number").Value );
       }
    }
