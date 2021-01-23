    if (checkAgeOfChildren == -1)
    {
      problem = "problem with age, stop checking";
      break;
    }
    if (!string.IsNullOrEmpty(problem)) {
       ViewBag.Message = problem;
    }
