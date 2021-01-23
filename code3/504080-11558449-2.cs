    protected valueAllocation MyObject
    {
       get
       {
          if(this.ViewState["c"] != null) 
               return (valueAllocation)this.ViewState["c"];
          return null;
      }
      set
      {
          this.ViewState["c"] = value;
      }
    public valueAllocation declaringValue()
    {
        if (this.MyObject == null)
            this.MyObject = new valueAllocation { MyValue = 5 };
        lblResult.Text="Value set here is:"+ this.MyObject.MyValue.ToString();
        return this.MyObject;
    }
    protected void btnSaveValue_Click(object sender, ImageClickEventArgs e)
    {
        declaringValue()
        lblResult.Text = "Value now is:" + declaringValue().MyValue.ToString();
    }
