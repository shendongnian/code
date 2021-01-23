    public void SetLabelBean(Label target, string value)
    {
      Label.Tag = value;
      Label.Text = Transform(value);
    }
    
    public string GetLabelBean(Label target)
    {
      return target.Tag as string;
    }
