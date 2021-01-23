    List<MyObject> obj = new List<MyObject>
    {
         new MyObject{ID=1, Text="this is some text"},
         new MyObject{ID=2, Text="text1"},
         new MyObject{ID=1, Text="more text"},
         new MyObject{ID=1, Text="a little more"},
         new MyObject{ID=2, Text="text 2"},
         new MyObject{ID=3, Text="XXX"}
    };
    List<MyObject> obj2 = new List<MyObject>(); //this list will hold your output
    //the linq query will filter out the uniques ids.
    var uniqueIds = (from a in obj select new { a.ID, a.Text }).GroupBy(x => x.ID).ToList();
    //then iterated through all the unique ids to merge the texts and list them under the unique ids.
    int id=0;
    foreach (var item in uniqueIds)
    {
        string contText = "";
        for (int j = 0; j < item.Count(); j++)
        {
            contText += item.ElementAt(j).Text + " ";
            id = item.ElementAt(j).ID;
        }
                       
        obj2.Add(new MyObject { ID = id, Text = contText });               
     }
