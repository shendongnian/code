    var itemToBeRemoved = objSessionResponseList
                        .FirstOrDefault(x=> 
                        x.QId == Convert.ToInt32(Session["QuestionNumber"]) &&
                        x.QAnswer == Session["CurrentAnswer"].ToString();
    if(itemToBeRemoved != null) //means item is found in the list
        objSessionResponseList.Remove(itemToBeRemoved)
          
                        
