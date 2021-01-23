    public FacebookOpenGraphActions Action { get; private set; }
    public PublishFacebookOpenGraphAction WithAction(FacebookOpenGraphActions action)
    {
        this.Action = action;
        return this;
    }
