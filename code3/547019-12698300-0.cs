    IEnumerable<SelectListItem> _possibilities 
    IEnumerable<SelectListItem> Possibilities 
    { 
       get
       {
           if (_possibilities == null)
               _possibilities = CommonLists.Possibilities();
           return possibilities;
       }
    }
