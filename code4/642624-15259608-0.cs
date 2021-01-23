    var rules = selections.GroupBy(rs => rs.RuleId)
                          .Select(g => new Rule {
                                      RuleId = g.Key,
                                      Criteria = g.Select(rs => rs.CriteriaId)
                                                  .Where(c => c != null)
                                                  .Select(c => c.Value)
                                                  .ToList(),
                                      CriteriaSource = g.Select(rs => rs.CriteriaSourceId)
                                                        .Where(c => c != null)
                                                        .Select(c => c.Value)
                                                        .ToList(),
                                  });
