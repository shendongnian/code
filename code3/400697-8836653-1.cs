    private void cIPLinkImpl(int paramCaseNo, int? paramIPID, string paramIPReference, int? paramContactID) {
        // Your implementation goes here.
        // check paramIPID and paramContactID to null before using them here
    }
    public void cIPLink(int paramCaseNo, int paramIPID, string paramIPReference, int paramContactID) {
        cIPLinkImpl(paramCaseNo, paramIPID, paramIPReference, paramContactID);
    }
    public void cIPLink(int paramCaseNo, string paramIPReference, int paramContactID) {
        cIPLinkImpl(paramCaseNo, null, paramIPReference, paramContactID);
    }
    public void cIPLink(int paramCaseNo, int paramIPID, string paramIPReference) {
        cIPLinkImpl(paramCaseNo, paramIPID, paramIPReference, null);
    }
