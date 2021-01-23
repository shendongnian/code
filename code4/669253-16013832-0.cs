    result.ResultantPoliciesTable
          .RemoveAll(item => 
                          result.PoliciesTable
                                .Where(i => i.ManagementID!=myId)
                                .Select(f => f.PolicyName)
                                .Contains(item.PolicyName)
                    );
