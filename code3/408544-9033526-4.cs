            /// <summary>
            /// gets a roommessage nood from CreateRoomMessageXElement
            /// and adds it to the related room XML file and saves it
            /// </summary>
            /// <param name="modelHesapAdi">a string which has the name of the XML file to be changed</param>
            /// <param name="incomingMemberHesapAdi">a string to be inserted to the xml file, which has the members name</param>
            /// <param name="entranceTime"> a string for time, holds the member's entrance time</param>
            public void AddMemberNodeToRoomMembersXMLWithGivenModelHesapAdiAndUyeHesapAdi(string modelHesapAdi, 
                                                                                          string incomingMemberHesapAdi,
                                                                                          string entranceTime)
            {
                XElement modelsXmlFile = BAL.Models.Model.LoadXMLWithGivenModelHesapAdi(modelHesapAdi, xmlDirectory);//loads the xml
                XElement roomMember = CreateRoomIncomingMemberXElement(incomingMemberHesapAdi, entranceTime);//creates child element and returns it
                modelsXmlFile.Add(roomMember);//adds the child element
                modelsXmlFile.Save(xmlDirectory + modelHesapAdi + ".xml");//saves the edited file
            }
