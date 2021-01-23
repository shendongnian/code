          [HttpPost]
          public ActionResult Budget(Proposal proposal)
          {
              if (ModelState.IsValid)
              {
                  var proposalToMerge = db.Proposals.Find(proposal.ProposalId);
                  UpdateModel(proposalToMerge);
                  // don't need this anymore as entity instance is being tracked
                  // db.Proposals.Attach(proposalToMerge );
                  // db.ObjectStateManager.ChangeObjectState(proposalToMerge , EntityState.Modified);
                  db.SaveChanges();
                  return RedirectToAction("Details", new {id = proposal.ProposalID});
              }
      
              return View(proposal);
          }
