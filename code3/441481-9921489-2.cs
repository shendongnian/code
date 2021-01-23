    @{
        var peopleList = Model.People.ToList();
    
        for( int i = 0; i < peopleList.Count; i++ )
        {
            @peopleList[i].Name
            if( i < peopleList[i].Count - 1 )
            {
                <text>,</text>
            }
        }
    }
