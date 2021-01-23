    var result =   xDoc.Descendants("VHost")
                       .Descendants("ConnectionsTotal")
                       .Select(ele => ele.Value )
                       .Select( value => new clsApplication
                               {
                                   ConnectionsTotal = value
                               })
                             ;
               
