        items = batch.Select(
                   b => b.Items.Where(
                                 i => i.ItemOrganisations.Any(
                                         o => o.Issues.Any(x => x.Code == issueNo)
                                      )
                        )
                ); 
