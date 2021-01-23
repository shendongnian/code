    public bool HasSetupDate {
      get {
        return this.SetupDate != DateTime.Min && this.SetupDate != null;
      }
    }
    public string SetupDate_Str {
      get{
        return this.SetupDate.ToString("MM/dd/yyyy");
      }
    }
    
