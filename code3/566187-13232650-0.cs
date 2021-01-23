    **The below code checks both the assignment and equal to operator in an assembly**
 
    public override ProblemCollection Check(Member member)
                {
                    var method = member as Method;
                    if (method == null)
                        return null;
                    if (method.Instructions.Count > 0)
                    {
                        foreach (var instruction in method.Instructions)
                        {
                            if (instruction != null)
                                if ( instruction.OpCode == OpCode.Ceq)
                                {
                                    var resolution = GetResolution(member.Name.Name);
                                    var problem = new Problem(resolution, member)
                                                      {
                                                          Certainty = 95,
                                                          FixCategory = FixCategories.Breaking,
                                                          MessageLevel = MessageLevel.Warning
                                                      };
                                    Problems.Add(problem);
                                }
                        }
                    }
                    return base.Problems;
                }
