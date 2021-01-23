    // call this once only e.g. Application_Start in the Global.asax
    Mapper.CreateMap<GroupPolicyViewModel, GroupPolicy>();
    ...
    // in your Adjustment action
    var groupPolicy = _service.GetGroupPolicy(viewModel.Id);
    groupPolicy = Mapper.Map<GroupPolicyViewModel, GroupPolicy>(viewModel, groupPolicy);
    _service.SaveGroupPolicy(groupPolicy);
