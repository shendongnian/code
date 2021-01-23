    public class MailingService : IMailingService
    {
        public bool RemoveSubscriber(string email, string list, string apiKey, bool deleteMember = true)
        {
            var mcApi = new MCApi(apiKey, true);
            var unsubscribeOptions = new List.UnsubscribeOptions();
            unsubscribeOptions.SendGoodby = false;
            unsubscribeOptions.SendNotify = false;
            unsubscribeOptions.DeleteMember = deleteMember;
            try
            {
                return mcApi.ListUnsubscribe(list, email, unsubscribeOptions);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddOrUpdateSubscriber(string email, string list, string apiKey)
        {
            var mcApi = new MCApi(apiKey, true);
            var merges = new List.Merges();
            var subscriptionOptions = new List.SubscribeOptions();
            subscriptionOptions.UpdateExisting = true;
            subscriptionOptions.DoubleOptIn = false;
            subscriptionOptions.SendWelcome = false;
            return mcApi.ListSubscribe(list, email, merges, subscriptionOptions);
        }
        public bool AddOrUpdateSubscriber(string email, string list, string apiKey, string firstName, string lastName, string title, string company, string guid)
        {
            var mcApi = new MCApi(apiKey, true);
            var merges = new List.Merges();
            merges.Add("FNAME", firstName);
            merges.Add("LNAME", lastName);
            merges.Add("TITLE", title);
            merges.Add("COMPANY", company);
            merges.Add("GUID", guid);
            var subscriptionOptions = new List.SubscribeOptions();
            subscriptionOptions.UpdateExisting = true;
            subscriptionOptions.DoubleOptIn = false;
            subscriptionOptions.SendWelcome = false;
            return mcApi.ListSubscribe(list, email, merges, subscriptionOptions);
        }
        public bool AddOrUpdateSubscriberPromo(string email, string list, string apiKey, string firstName, string lastName, string title, string company, string interests, string guid)
        {
            var mcApi = new MCApi(apiKey, true);
            var merges = new List.Merges();
            merges.Add("FNAME", firstName);
            merges.Add("LNAME", lastName);
            merges.Add("TITLE", title);
            merges.Add("COMPANY", company);
            merges.Add("GUID", guid);
            merges.Add("INTERETS", interests);
            var subscriptionOptions = new List.SubscribeOptions();
            subscriptionOptions.UpdateExisting = true;
            subscriptionOptions.DoubleOptIn = false;
            subscriptionOptions.SendWelcome = false;
            return mcApi.ListSubscribe(list, email, merges, subscriptionOptions);
        }
        public bool UpdateSubscriberEmail(string oldEmail, string newEmail, string apiKey)
        {
            var mcApi = new MCApi(apiKey, true);
            var merges = new List.Merges();
            var subscriptionOptions = new List.SubscribeOptions();
            subscriptionOptions.UpdateExisting = true;
            subscriptionOptions.DoubleOptIn = false;
            subscriptionOptions.SendWelcome = false;
            return mcApi.ListUpdateMember().ListSubscribe(list, email, merges, subscriptionOptions);
        }
        public bool SendCampaign(string url, string urlParams, string fromEmail, string fromName, string list, string emailSubject, string camapaignTitle, List<string> emails, string apiKey)
        {
            var mcApi = new MCApi(apiKey, true);
            var options = new Campaign.Options(list, camapaignTitle, fromEmail, fromName, fromName); 
            var content = new Campaign.Content.Html();
          
            var guid = Guid.NewGuid();
            var segmentName = "qi_" + guid;
            
            var segmentId = 0;
            if(segmentId == 0) segmentId = mcApi.ListStaticSegmentAdd(list, segmentName);
            mcApi.ListStaticSegmentMembersAdd(list, segmentId, emails);
            var segmentIds =  new List<string>();
            segmentIds.Add(segmentId.ToString());
            var condition = new Campaign.SegmentCondition("static_segment", "eq", segmentIds);
            var conditions = new MCList<Campaign.SegmentCondition>();
            conditions.Add(condition);
            var segmentOptions = new Campaign.SegmentOptions(Campaign.Match.AND, conditions);
            content.Url = url;
            
            var success = false;
            LogManager.GetLogger(GetType().FullName + " " + camapaignTitle).Info("Test de campagne" + " / Nb emails : " + emails.Count + " / Url : " + url);
            try
            {
                var id = mcApi.CampaignCreate(Campaign.Type.Regular, options, content, segmentOptions);
                LogManager.GetLogger(GetType().FullName + " " + camapaignTitle).Info("Création de campagne - " + id);
                try
                {
                    success = !string.IsNullOrEmpty(id) && mcApi.CampaignSendNow(id);
                    LogManager.GetLogger(GetType().FullName + " " + camapaignTitle).Info("Envoi de campagne - " + id + " Statut : " + success + " / Nb emails : " + emails.Count + " / Url : " + url);
                    return success;
                }
                catch (Exception ex)
                {
                    LogManager.GetLogger(GetType().FullName + " " + camapaignTitle).Fatal(string.Format("Erreur lors de l'envoi d'une campagne {0} {1}", ex.Message, ex.StackTrace));
                }
            }
            catch(Exception ex)
            {
                LogManager.GetLogger(GetType().FullName + " " + camapaignTitle).Fatal(string.Format("Erreur lors de la création d'une campagne {0} {1}", ex.Message, ex.StackTrace));
            }
            return success;
        }
