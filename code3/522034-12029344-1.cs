    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Collections;
    namespace WCFJobsLibrary
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJobs" in both code and config file together.
        [ServiceContract]
        public interface IJobs
        {
             //Directoy Manager
             [OperationContract]
            ReturnClass FindDrives();
             //Directoy Manager
             [OperationContract]
             ReturnClass FindSubfolders(String Folder_To_Search);
             //Directoy Manager
             [OperationContract]
             ReturnClass FindSubFiles(String Folder_To_Search);
             //Directoy Manager
             [OperationContract]
             ReturnClass FilesToControl(List<Item> ItemsToControl);        
    
        }
    
    
            [DataContract]
          //  [KnownType(typeof(List<Item>))]
            [KnownType(typeof(Item))] 
               public class Item
           {
               public Item(string Paramater, string Type)
               {         
                   _Paramater = Paramater;
                   _Type = Type;
               }
               private string _Paramater;
                [DataMember]
               public string Paramater
               {
                   get { return _Paramater; }
                   set { _Paramater = value; }
               }
                private string _Type;
                [DataMember]
               public string Type
               {
                   get { return _Type; }
                   set { _Type = value; }
               }
    
           }
    
    
    
      
    }
