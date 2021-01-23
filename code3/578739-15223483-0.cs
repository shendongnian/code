                BMC.ARSystem.Server arserver = new BMC.ARSystem.Server();
                arserver.Login("servername", "username", "password", "");
             //Search a Remedy Form Start
                string RequestID = "000000000000001";
                string FromForm = ((BMC.ARSystem.EntryDescription)arserver.GetListEntry("someREMEDYform", string.Format("'1' = \"{0}\"", RequestID))[0]).Description;
              
                string qualification = string.Format("'1' = "+ RequestID );
                
                BMC.ARSystem.EntryListFieldList fieldList = new BMC.ARSystem.EntryListFieldList();
                fieldList.Add(new BMC.ARSystem.EntryListField(8));
                fieldList.Add(new BMC.ARSystem.EntryListField(3));
                var entryList = arserver.GetListEntryWithFields("someREMEDYform", qualification, fieldList, 0, 0);
                Console.WriteLine(entryList[0].FieldValues[8]);
                Console.WriteLine(entryList[0].FieldValues[3]);
              
                
                Console.ReadLine();
                //Search a Remedy Form End
