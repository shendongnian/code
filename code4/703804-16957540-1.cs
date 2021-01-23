    public void SetTextOnControlName(string name, string newText)
    {
      var ctrl = Controls.First(c => c.Name == name);
      ctrl.Text = newTExt;
    }
