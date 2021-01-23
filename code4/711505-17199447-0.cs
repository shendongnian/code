              .Events(events =>
                  {
                      events.Edit("edit_handler");
                  })
              .DataSource(dataSource => dataSource
                                            .Ajax()
                                            .PageSize(10)
                                            .Events(events => events.Error("error_handler"))
                                            .Model(model =>
                                                {
                                                    model.Id(m => m.MilestoneId);
                                                    model.Field(m => m.ProjectName).Editable(false);
                                                    model.Field(m => m.Name).Editable(false);
                                                    model.Field(m => m.Status).Editable(true);
                                                })
