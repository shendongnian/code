    using System.Data.Entities;                                    // notice using
    
    var query = (from p in context.People
                                  .Include(p => p.PeopleClub)      // notice lambda instead of string
                                  .Include(p => p.PeopleClub.Club)
                 //let s = p.PeopleClub.DisplaySequence            // may use for readability
                 orderby p.FirstName, p.PeopleClub.DisplaySequence
                 select p).ToList();
