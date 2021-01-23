        if (ExecutionContext.IsFlowSuppressed())
        {
          IWebProxy webProxy = (IWebProxy) null;
          if (this.useProxy)
            webProxy = this.proxy ?? WebRequest.DefaultWebProxy;
          if (this.UseDefaultCredentials || this.Credentials != null || webProxy != null && webProxy.Credentials != null)
            this.SafeCaptureIdenity(state);
        }
