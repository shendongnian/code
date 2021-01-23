    public void ForceUpdateErrors() {
        var tmpInnerVM = _mainViewModel.InnerViewModel;
        _mainViewModel.InnerViewModel = null;
        _mainViewModel.InnerViewModel = tmpInnerVM;
    }
