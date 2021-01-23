            /// <summary>
            /// creates and returns roommessage nood
            /// </summary>
            /// <param name="memberHesapAdi">the sender of the message</param>
            /// <param name="message">sent message</param>
            /// <param name="timeSent">the time when the message was sent</param>
            /// <returns></returns>
            private XElement CreateRoomIncomingMemberXElement(string memberHesapAdi, string entranceTime)
            {
                XElement roomMessage = new XElement("RoomMember",
                                                                new XElement("MemberHesapAdi", memberHesapAdi),
                                                                new XElement("Time", entranceTime));
                return roomMessage;
            }
