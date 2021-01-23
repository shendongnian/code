     var QueueByTeam = db.Calls.Where(x => x.assignedteam == id)
         .Select(call => new CallVM
          {
              customer = call.customer,
              nexttargetdate = call.nexttargetdate
              owner = "";
          })
          .ToList();
        foreach (var calls in QueueByTeam)
        {
            calls.owner = "--------";
        }
        // at this point, QueueByTeam has ignored changing the `owner` field to "-------"           
        return View(QueueByTeam);
