    Microsoft.Xrm.Sdk.EntityReference moniker = new Microsoft.Xrm.Sdk.EntityReference();
                    moniker.LogicalName = "contract";
                    moniker.Id = newContractId;
                    Microsoft.Xrm.Sdk.OrganizationRequest request = new Microsoft.Xrm.Sdk.OrganizationRequest() { RequestName = "SetState" };
                    request["EntityMoniker"] = moniker;
                    OptionSetValue state = new OptionSetValue(1);//Active
                    OptionSetValue status = new OptionSetValue(2);//Invoiced
                    request["State"] = state;
                    request["Status"] = status;
                    _service.Execute(request);
