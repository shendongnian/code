        SCardContext context = new SCardContext();
        context.Establish(SCardScope.System);
        string[] readers = context.GetReaders();
        IsoReader isoReader = new IsoReader(context, readers[3], SCardShareMode.Shared, SCardProtocol.Any, false);
        CommandApdu apdu = new CommandApdu(IsoCase.Case4Short, isoReader.ActiveProtocol)
        {
            CLA = 0x00,
            Instruction = InstructionCode.SelectFile,
            P1 = 0x04,
            P2 = 0x00,
            Data = new byte[] { 0xa0, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00 }
        };
        Response response = isoReader.Transmit(apdu);
        GlobalPlatform gp = new GlobalPlatform();
        KeySet scKeys = new KeySet();
        scKeys.MacKey = new Key("404142434445464748494a4b4c4d4e4f");
        scKeys.EncKey = new Key("404142434445464748494a4b4c4d4e4f");
        scKeys.KekKey = new Key("404142434445464748494a4b4c4d4e4f");
        CommandAPDU initUpdate = gp.CreateInitUpdateCommand(scKeys,
            SecurityLevel.C_DECRYPTION | SecurityLevel.C_MAC, GlobalPlatform.SCP_ANY, GlobalPlatform.IMPL_OPTION_ANY);
        apdu = new CommandApdu(IsoCase.Case4Short, isoReader.ActiveProtocol)
        {
            CLA = (byte)initUpdate.CLA,
            INS = (byte)initUpdate.INS,
            P1 = (byte)initUpdate.P1,
            P2 = (byte)initUpdate.P2,
            Data = initUpdate.Data
        };
        response = isoReader.Transmit(apdu);
        if (response.SW1 == 0x6C)
        {
            apdu = new CommandApdu(IsoCase.Case2Short, isoReader.ActiveProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.GetResponse,
                P1 = 0x00,
                P2 = 0x00,
                Le = response.SW2
            };
            response = isoReader.Transmit(apdu);
        }
        byte[] responseData = response.GetData();
        gp.ProcessInitUpdateResponse(new ResponseAPDU(response.SW1, response.SW2, responseData));
        CommandAPDU extAuth = gp.CreateExternalAuthCommand();
        apdu = new CommandApdu(IsoCase.Case3Short, isoReader.ActiveProtocol)
        {
            CLA = (byte)extAuth.CLA,
            INS = (byte)extAuth.INS,
            P1 = (byte)extAuth.P1,
            P2 = (byte)extAuth.P2,
            Data = extAuth.Data
        };
        response = isoReader.Transmit(apdu);
        gp.ProcessExternalAuthResponse(new ResponseAPDU(response.SW1, response.SW2, response.GetData()));
        Key newMacKey = new Key("505152535455565758595a5b5c5d5e5f", 0, 0);
        Key newEncKey = new Key("505152535455565758595a5b5c5d5e5f", 1, 0);
        Key newKekKey = new Key("505152535455565758595a5b5c5d5e5f", 2, 0);
        List<Key> newKeys = new List<Key>();
        newKeys.Add(newMacKey);
        newKeys.Add(newEncKey);
        newKeys.Add(newKekKey);
        CommandAPDU putKey = gp.CreatePutKeyCommand(newKeys, true, false, GlobalPlatform.KEY_FORMAT_1);
        apdu = new CommandApdu(IsoCase.Case3Short, isoReader.ActiveProtocol)
        {
            CLA = (byte)putKey.CLA,
            INS = (byte)putKey.INS,
            P1 = (byte)putKey.P1,
            P2 = (byte)putKey.P2,
            Data = putKey.Data
        };
        response = isoReader.Transmit(apdu);
        if (response.SW1 == 0x6C)
        {
            apdu = new CommandApdu(IsoCase.Case2Short, isoReader.ActiveProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.GetResponse,
                P1 = 0x00,
                P2 = 0x00,
                Le = response.SW2
            };
            response = isoReader.Transmit(apdu);
        }
    }
