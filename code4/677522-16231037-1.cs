    public void PresentationMethod()
    {
       try
       {
          _bll.BusinessMethod();
       }
       catch(BusinessException be)
       {
          var errorMessage = GetErrorMessage(be.ErrorCode);
          ShowErrorUI(errorMessage);
       }
    }
