    public ctr()
    {
        DateTime date = new DateTime(2012 , 12, 03); ;
    
        for (int i = 0; i < 5; i++)
        {
            LkVisiteurIdDTO visitid= new LkVisiteurIdDTO(10, 11, 12);
            PurgeDateTimeDTO datetime= new PurgeDateTimeDTO(date, true);
            ContractProtoBuf proto = new ContractProtoBuf();
            proto.m_Index = i + 1;
            proto.m_TechnicalKey = "m_TechnicalKey" + i;
            proto.m_LogicalKey = visitid;
            proto.m_PurgeTime = datetime;
    
            protoContractList.Add(proto);
        }    
    }
