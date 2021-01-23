    private void handleEachSession(XElement session)
    {
        XElement receivedSessionId = session.XPathSelectElement("sessionId");
        XElement receivedQuality = session.XPathSelectElement("quality");
        XElement receivedContentStatus = session.XPathSelectElement("contentStatus");
    }
