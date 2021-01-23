    public JsonResult GetMessageContent(long MessageTypeID)
    {
        tblMessageType tblMessageType = db.tblMessageTypes.Single(t => t.MessageTypeID == MessageTypeID);
        return Json(tblMessageType.MessageContent, JsonRequestBehavior.AllowGet);
    }
