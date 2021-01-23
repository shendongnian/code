     protected override void OnError(DomainServiceErrorInfo errorInfo)
     {
         if (errorInfo.Error is UnauthorizedAccessException)
         {
             errorInfo.Error = new DomainException("Denied access.",(int)MyErrorCodesEnum.Permission_Unauthorized, errorInfo.Error);
         }
     }
