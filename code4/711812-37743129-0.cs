    DecodedShortMessage[] messages = comm.ReadMessages(PhoneMessageStatus.All, storage);
                foreach (DecodedShortMessage message in messages)
                {
                    GsmComm.PduConverter.SmsDeliverPdu SMSPDU;
                    SMSPDU = (GsmComm.PduConverter.SmsDeliverPdu)message.Data;
                    bool Is_Multi_PART = SmartMessageDecoder.IsPartOfConcatMessage(SMSPDU); 
                    byte[] element1 = message.Data.UserData;
                    if (element1[0] == 5)
                    {
                        byte[] numArray = new byte[2];
                        numArray[0] = element1[3];
                        numArray[1] = element1[2];
                        int referenceNumber = BitConverter.ToUInt16(numArray, 0);
                        int totalMessages = element1[4];
                        int currentNumber = element1[5];
                    }
                }
