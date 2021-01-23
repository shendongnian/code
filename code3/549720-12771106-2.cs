    IEnumerable<Info> previousNextInfo (IEnumerable<QuestionType> sourceEnumerable) {
       Info preprevious = null;
       Info previous = null;
       Info current = null;
       foreach (Info newOne in sourceEnumerable) {
          preprevious = previous;
          previous = current;
          current = newOne;
          yield return new Info () {
             QuestionID = previous.ID,
             lastID = preprevious != null ? preprevious.ID : null,
             nextID = current.ID
          };
       }
       if (current != null)
          yield return new Info () { QuestionID = current.ID, lastID = previous.ID, nextID = null };
    }
    
    ...
    
    questionList = previousNextInfo (dc.Question 
            .Where(i => !i.IsDeleted) 
            .OrderBy(i => i.SortOrder)
    ).ToList ();
