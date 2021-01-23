                    HttpResponseMessage responseGetEmailByPersonsBare =
                             await clientGetEmailByPersonsBare.PostAsync(UrlBase + EmailDetailGetEmailByPersonsBare, contentGetEmailByPersonsBare);
                         Stream myStream = await responseGetEmailByPersonsBare.Content.ReadAsStreamAsync();
                         var djsGetEmailByPersonsBare = new DataContractJsonSerializer(typeof(AEWebDataStructures.RootObjectEmailDetail));
                         var rootObjectEmailDetail = (AEWebDataStructures.RootObjectEmailDetail)djsGetEmailByPersonsBare.ReadObject(myStream);
                         responseGetEmailByPersonsBare.EnsureSuccessStatusCode();
                         returnTaskInfo.EmailDetails = rootObjectEmailDetail.Data;
                         returnTaskInfo.StatusReturn = AEWebDataStructures.StatusReturn.Success;
