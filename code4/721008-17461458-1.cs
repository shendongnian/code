    private VAEmpresa _dev;
    public virtual VAEmpresa Dev  // Reference Object
    {
      get { return this._idDev; }
      set 
      { 
          this._idDev = value; 
          if(_idDev != null)      // assure that with reference change
          {                       // the referenceId is changed as well
              IdDev = _idDev.Id
          }
      }
    }
    public virtual int IdDev { get; set; } // Refernece Id
