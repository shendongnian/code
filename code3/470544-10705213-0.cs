    string line = sr.ReadLine();
    QuickFix42.MessageFactory fac = new QuickFix42.MessageFactory();
    QuickFix.MsgType msgType = QuickFix.Message.identifyType(line);
    QuickFix.Message message = fac.create("", msgType.getObject() as string);
    message.setString(line, false);
