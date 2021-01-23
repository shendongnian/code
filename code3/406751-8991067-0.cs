    public Guid AccountId {
        get { return _accountId; }
        set {
            _accountId = value;
            OnAccountIdChanged();
        }
    }
    protected virtual void OnAccountIdChanged() {
        if(AccountId != Guid.Empty) {
           //do your thing here
        }
    }
