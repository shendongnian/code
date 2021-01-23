    private string labelText;
    public DLG Dtype { get; set; }
    public string LabelText 
    {
      get { return this.labelText; }
      set
      {
        this.labelText = value;
        label1.Text = value;
      }
    }
