    //When this list is loaded, every item in it is there twice or three times or four... Why???? 
    TopicList Index = null; 
    Index = (TopicList)presentation["INDEX"]; 
 
    for (int i = 0; i < topics.Count; ) 
    { 
        topics.RemoveAt(i); 
    } 
 
    foreach (TopicListItem item in Index.Topics) 
    { 
        topics.Insert(item.TopicIndex, (Topic)presentation[item.ResourceKey]); 
    } 
 
    Index.Topics.Clear();        //Adding this will prevent the duplication
    lv_topics.SelectedIndex = 0; 
    selectedIndex = 0; 
