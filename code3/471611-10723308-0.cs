    public class OpenIdRelyingPartyWrapped
    {
        private OpenIdRelyingParty openIdRelyingPartyTarget;
        ....
        public virtual IAuthenticationRequest CreateRequest(string text)
        {
            return this.openIdRelyingPartyTarget.CreateRequest(text);
        }
        ...
    } 
