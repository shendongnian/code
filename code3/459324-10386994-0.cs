    internal void SetDirty()
    {
      if (this._hasBeenCommitted || this._configurationManager.Owner.ReadOnly)
        throw new InvalidOperationException(Resources.ObjectHasBeenCommited);
      this._isDirty = true;
    }
