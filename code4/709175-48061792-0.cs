                    ListToGetJwToMfData = (from master in getJwtMF.Tables["gst_jobwork_to_mfgmaster"].AsEnumerable() select new GSTEntity.gst_jobwork_to_mfgmaster { Partygstin = master.Field<string>("Partygstin"), Partystate =
                                           master.Field<string>("Partystate"), NatureOfTransaction = master.Field<string>("NatureOfTransaction"), ChallanNo = master.Field<string>("ChallanNo"), ChallanDate=master.Field<int>("ChallanDate"),  OtherJW_ChallanNo=master.Field<string>("OtherJW_ChallanNo"),   OtherJW_ChallanDate = master.Field<int>("OtherJW_ChallanDate"),
                        OtherJW_GSTIN=master.Field<string>("OtherJW_GSTIN"),
                        OtherJW_State = master.Field<string>("OtherJW_State"),
                        InvoiceNo = master.Field<string>("InvoiceNo"),
                        InvoiceDate=master.Field<int>("InvoiceDate"),
                        Description =master.Field<string>("Description"),
                        UQC= master.Field<string>("UQC"),
                        qty=master.Field<decimal>("qty"),
                        TaxValue=master.Field<decimal>("TaxValue"),
                        Id=master.Field<int>("Id")                        
                    }).ToList();
