    IEnumerable<TableProperties> tableProperties = bd.Descendants<TableProperties>().Where(tp => tp.TableCaption != null);
    foreach(TableProperties tProp in tableProperties)
    {
        if(tProp.TableCaption.Val.Equals("myCaption")) // see comment, this is actually StringValue
        {
            // do something for table with myCaption
            Table table = (Table) tProp.Parent;
        }
    }
    
