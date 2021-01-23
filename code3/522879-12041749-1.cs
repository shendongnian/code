    public void btnAnalyze_onClick(){
        List<Item> results = new ArrayList<Item>();
        if(txtComAuthor.Text != String.Empty)
        { 
           List<Item> matched = filterByAuthor(txtComAuthor.Text);
           results.addRange(matched);
        }
        if(txtComStartDate.Text != String.Empty)
        {
           List<Item> matched = filterByStartDate(txtComStartDate.Text);
           results.addRange(matched);
        }
        // do the same for the others
        return results;
    }
   
    public List<Item> filterByAuthor(String desiredAuthorName){
          List<Item> matches = new ArrayList<Item>();
          //have your data access piece here, from DB/Excel/whatever.
          List<Item> candidates = ...
          foreach(Item candidate in candidates){
             if(candidate.ToLower() == desiredAuthorName){ 
                matches.add(candidate)
             }
           }
           return matches;
    }
