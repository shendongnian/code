    public ActionResult DisplayCardsResults(int _page, string _sortOrder, string _filter = "", string _searchValue = "")
    {
      ViewBag._filter = _filter;
      ViewBag._searchValue= _searchValue;
    
      //Do whatever you are doing to get the cards but to the resultant collection add the following where condition, suppose the collection is in var cards
    
    
     switch (_filter)
                {
                    case "cardRarity":
                        cards = cards.Where(s => s.CardRarity == _searchValue);
                        break;
                    case "cardType":
                        cards = cards.Where(s => s.CardType == _searchValue);
                        break;
                    case "cardColor":
                        cards = cards.Where(s => s.CardColor == _searchValue);
                        break;
                    default:
                        // no filter
                        break;
                }
       if(Request.isAjaxRequest)
          return PartialView("_ResultsTable",cards);
      return View(cards);
    }
