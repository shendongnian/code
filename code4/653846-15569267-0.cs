	private bool CheckName(string eval, string name)
	{
		return new Regex(eval, RegexOptions.IgnoreCase).Match(name).Success;
	}
	private bool CheckName(List<string> evals, string name, bool all)
	{
	  if (all == true)
	  {
		return !evals.Any(eval => !CheckName(eval, name));
	  }
	  else
	  {
		return evals.Any(eval => CheckName(eval, name));
	  }
	}
