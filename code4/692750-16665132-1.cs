    var model = new MyModel();
    model.Policies = po
        .Select(p => new SelectListItem
        {
            Text = p.PolicyName,
            Value = p.PolicyID.ToString(),
            Selected = p.PolicyID == currentPolicyId //change that to whatever current is
        })
        .ToList();
