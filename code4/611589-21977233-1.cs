            TEST ci = new TEST(); ci._Items = new List<TEST>(); ci.NameItemType = "ROOT_ITEM";
            TEST ci_2 = new TEST(); ci_2._Items = new List<TEST>(); ci_2.NameItemType = "ITEM_02"; ci.AddItem(ci_2);
            TEST ci_3 = new TEST(); ci_3._Items = new List<TEST>(); ci_3.NameItemType = "ITEM_03"; ci_2.AddItem(ci_3);
            // --> Confirm references.
            bool AreEqual = false;
            if (ci == ci_2.Parent)
                AreEqual = true;
            if (ci_2 == ci_3.Parent)
                AreEqual = true;
            // --> Serialize.
            byte[] buf;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, ci);
                buf = ms.ToArray();
            }
            // --> Deserialize.
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(buf))
            {
                ci = ProtoBuf.Serializer.Deserialize<TEST>(ms);
            }
            // --> Confirm references.
            ci_2 = ci._Items[0];  
            ci_3 = ci_2._Items[0];
            if (ci == ci_2.Parent)
                AreEqual = true;
            if (ci_2 == ci_3.Parent)  // HERE IS WHERE IT FAILS! 
                                      // THEY SHOULD BE EQUAL AFTER DESERIALIZATION!
                AreEqual = true;    
