    // Wrong (type error)
    from p in people
      .Where(
         // Results in type error as result of Where is Enumerable, not bool.
         // The lambda signature is People => IEnumerable[Award] which is
         // incompatible with People => bool.
         a => a.Awards.Where(a => a.AwardID == 5)
      )
    select p
    // Working - but NOT ideal as it forces materialization of the
    // matching award count! However, types are correct.
    from p in people
      .Where(
         // Now we get a lambda: People => bool
         a => a.Awards.Where(a => a.AwardID == 5).Count() > 0
      )
    select p
