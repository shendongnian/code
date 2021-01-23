    [__DynamicallyInvokable]
    public virtual string Message
    {
      [__DynamicallyInvokable] get
      {
        if (this._message != null)
          return this._message;
        if (this._className == null)
          this._className = this.GetClassName();
        return Environment.GetRuntimeResourceString("Exception_WasThrown", new object[1]
        {
          (object) this._className
        });
      }
    }
