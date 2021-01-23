    Submissions.Select(sub => new
    {
      //...other fields
      Votes = Votes.Where(vote => vote.Fk_id == sub.Id)
                   .GroupBy(vote => vote.Fk_id)
                   .Select(group => group.Count()),
    }
