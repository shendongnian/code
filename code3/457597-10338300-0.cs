    var fromAtoC =  Model.Items.Where(x => x.Title != null && x.Title[0] >= 'A' && x.Title[0] <= 'C');
    for(int i=0; i < fromAtoC.Count(); i++)
    {
           //Do some stuff
    }
    var fromDtoF =  Model.Items.Where(x => x.Title != null && x.Title[0] <= 'D' && x.Title[0] >= 'F');
    for(int i=0; i < fromDtoF.Count(); i++)
    {
           //Do some stuff
    }
