    public ActionList Adjustment(GroupPolicyViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            // pull actual entity from service
            var groupPolicy = _service.GetGroupPolicy(viewModel.Id);
            // update entity from view model
            groupPolicy.Name = viewModel.Name;
            groupPolicy.Description = viewModel.Description;
            ...
        }
    }
