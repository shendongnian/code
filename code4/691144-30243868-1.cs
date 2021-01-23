    public override void ApplyClientCredential(string clientIdentifier, HttpWebRequest request)
    {
      if (clientIdentifier == null)
        return;
      if (this.credential != null)
        ErrorUtilities.VerifyHost((string.Equals(this.credential.UserName, clientIdentifier, StringComparison.Ordinal) ? 1 : 0) != 0, "Client identifiers \"{0}\" and \"{1}\" do not match.", (object) this.credential.UserName, (object) clientIdentifier);
      OAuthUtilities.ApplyHttpBasicAuth(request.Headers, clientIdentifier, this.clientSecret);
    }
