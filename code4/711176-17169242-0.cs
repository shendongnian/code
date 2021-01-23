    var model = new Models.HammerpointVideoListModel();
    List<SelectListItem> list = new List<SelectListItem>();
    
    foreach (var video in Videos)
    {
        list.Add(new SelectListItem()
                    {
                        Selected=false,
                        Value = video.VideoLink,
                        Text = video.VideoName
                    });
    
    }
    
    model.VideoList = list;
