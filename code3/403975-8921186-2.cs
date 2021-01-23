    [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, string[] selectedTypes)
        {
            SystemFailureProblem problem = (from p in context.SystemFailureProblems
                                            where p.ID == id
                                            select p).Single();
            // get all types joined with this problem using cross table
            var problemTypes = from x in context.xSystemFailureProblemToTypes
                               join t in context.SystemFailureTypes on x.SystemFailureTypeID equals t.ID
                               where x.SystemFailureProblemID == problem.ID
                               select t;
            problem.FailureTypes = problemTypes.ToList<SystemFailureType>();
            if (TryUpdateModel(problem, "", null, new string[] { "Types" }))
            {
                try
                {
                    // loop through all types in the system
                    foreach (var failureType in context.SystemFailureTypes)
                    {
                        // determine if checkbox for current type was checked
                        if (selectedTypes.Contains(failureType.ID.ToString()))
                        {
                            // if no joining record exists (type not previously selected), create a joining record
                            if (!problemTypes.Contains(failureType))
                            {
                                context.xSystemFailureProblemToTypes.InsertOnSubmit(
                                    new xSystemFailureProblemToType
                                    {
                                        SystemFailureProblemID = problem.ID,
                                        SystemFailureTypeID = failureType.ID
                                    });
                            }
                        }
                        else
                        {
                            // if type was unchecked but joining record exists, delete it
                            if (problemTypes.Contains(failureType))
                            {
                                xSystemFailureProblemToType toDelete = (from x in context.xSystemFailureProblemToTypes
                                                                        where x.SystemFailureProblemID == problem.ID &&
                                                                        x.SystemFailureTypeID == failureType.ID
                                                                        select x).SingleOrDefault();
                                context.xSystemFailureProblemToTypes.DeleteOnSubmit(toDelete);
                            }
                        }
                    }
                    context.SubmitChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            PopulateSystemFailureProblemData(problem);
            return View(problem);
        }
