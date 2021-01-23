    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ConsoleApplication2.TestService;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication2
    {
        public class Customer
        {
            public string customerId { get; set; }
            public string CustomerName { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public StudyInfoType[] StudyInfo { get; set; }
            public string visited { get; set; }
            public string billingId { get; set; }
            public string RegDate { get; set; }
            public string uploaded { get; set; }
        }
    
        public class StudyInfoType
        {
               string Modality {get; set;}
               string StudyName {get; set;}
               string ModalityId {get; set;}
               string StudyID {get; set;}
               string visitid {get; set;}
               string billingId {get; set;}
               string RegDate {get; set;}
               string uploaded {get; set;}
               string groupid { get; set; }
        }
    
    
        class Program
        {
            static void Main()
            {
                var temp = CustomerInfo(@"[{ 'customerId':'123', 'CustomerName':'', 'Age':39,'Gender':'Male','StudyInfo':[{'Modality':'XRAY','StudyName':'Test Name','ModalityId':'1','StudyID':'10923','visitid':41549113,'billingId':'456','RegDate':'mm/dd/yyyy','uploaded':'1','groupid':'1'},{'Modality':'XRAY','StudyName':'CT Test Name','ModalityId':'1','StudyID':'10924','visitid':41549113,'billingId':'459','RegDate':'mm/dd/yyyy','uploaded':'1','groupid':'1'}]},{'customerId':'928','CustomerName':'','Age':49,'Gender':'FeMale','StudyInfo':[{'Modality':'XRAY','StudyName':'Test Name','ModalityId':'1','StudyID':'10923','visitid':41549113,'billingId':'456','RegDate':'mm/dd/yyyy','uploaded':'1','groupid':'1'},{ 'Modality':'XRAY','StudyName':'CT Test Name','ModalityId':'1','StudyID':'10924','visitid':41549113,'billingId':'459','RegDate':'mm/dd/yyyy','uploaded':'1','groupid':'1' } ] } ]");
            }
    
            public static List<Customer> CustomerInfo(string json)
            {
                var n = JsonConvert.DeserializeObject(json, new JsonSerializerSettings
                {
                    ObjectCreationHandling = ObjectCreationHandling.Replace
                });
                return JsonConvert.DeserializeObject<List<Customer>>(json);
            }
        }
    }
