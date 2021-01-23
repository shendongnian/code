    using System.Collections.Generic;
    using Mail;
    namespace Mail.Models
    {
        public class SubscriberCheckedModel
        {
            public Subscriber subscriber { get; set; }
            public bool AddToGroup { get; set; }
        }
    
        public class SubscriberCheckedListViewModel
        {
            int GroupId{get;set;}
            public IEnumerable<SubscriberCheckedModel> subscribers { get; set; }
        }
    }
