    var objectives = objectiveData.Select(o => {
            var result = new Objective {
                            Name = o.Name,
                            Text = o.Text
            };
            if (o.Name != null && o.Name.EndsWith("01"))
            {
                result.ObjectiveDetails.Add
                (
                    new ObjectiveDetail
                    {
                        Text = o.Text
                    }
                );
            }
            //you miss this
            return result;
        });
