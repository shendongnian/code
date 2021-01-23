    public ActionResult Edit(int id)
        {
            SystemFailureProblem problem = (from p in context.SystemFailureProblems
                                            where p.ID == id
                                            select p).Single();
            PopulateSystemFailureProblemData(problem);
            return View(problem);
        }
        public void PopulateSystemFailureProblemData(SystemFailureProblem problem)
        {
            // get all failure types
            var allTypes = from t in context.SystemFailureTypes select t;
            // get al types joined with this problem using cross table
            var problemTypes = from x in context.xSystemFailureProblemToTypes
                               join t in context.SystemFailureTypes on x.SystemFailureTypeID equals t.ID
                               where x.SystemFailureProblemID == problem.ID
                               select t;
            // construct view model collection
            List<SystemFailureProblemTypeViewModel> viewModel = new List<SystemFailureProblemTypeViewModel>();
            foreach (var type in allTypes)
            {
                viewModel.Add(new SystemFailureProblemTypeViewModel
                {
                    TypeID = type.ID,
                    TypeDescription = type.Description,
                    Assigned = problemTypes.Contains(type)
                });
            }
            ViewBag.Types = viewModel;
        }
