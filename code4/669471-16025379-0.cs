    public string Content
    {
       get
       { 
          // bounds checking here..
          return contentWithListView[this.SelectNumberStep];
       }
    }
    public int SelectNumberStep
    {
        get
        {
            return this.selectNumberStep;
        }
        
        set
        {
            this.selectNumberStep = value;
            this.NotifyOfPropertyChange(() => this.SelectNumberStep);
            this.NotifyOfPropertyChange(() => this.Content);
        }
    }
    <TextBox Text="{Binding Content}" ... />
