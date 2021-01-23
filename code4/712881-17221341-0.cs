            StatusSelectList = AllStatus.Select(x =>
                                            new StatusSelectListItem
                                            {
                                                Text = x.Description,
                                                Value = x.id.ToString()
                                            }).ToList();
            this.SelectedStatusIndex = 2;//Default Status is New
