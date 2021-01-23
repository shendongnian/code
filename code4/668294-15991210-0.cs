    public virtual void UpdateItem(bool causesValidation)
        {
          this.ResetModelValidationGroup(causesValidation, string.Empty);
          this.HandleUpdate(string.Empty, causesValidation);
        }
    private void HandleUpdate(string commandArg, bool causesValidation)
        {
           // Lots of work is done here
        }
