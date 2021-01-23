    class HardDrive
    {
       private int index;
       private ManagmentObject physicalMediaInfo;
       private ManagementObject smartDataInfo;
       
       // choose one of these constructors.  this one lets you delay all the WMI calls till you need to do them 
       public HardDrive(int index)
       {
           this.index=index;
       }
       //this one means you have to make the calls in advance
       public HardDrive(ManagmentObject physicalMediaInfo,ManagementObject smartDataInfo)
       {
           this.physicalMediaInfo=physicalMediaInfo;
           this.smartDataInfo=smartDataInfo;
       }
       private ManagementObject PhysicalMediaInfo
       {
           get
           { 
              if(physicalMediaInfo==null)
              {
                  ManagementObject[] WMIData = DataRetriever.GetWMIData("Win32_PhysicalMedia");
                  physicalMediaInfo=WMIData[index];
              } 
              return physicalMediaInfo;         
           }
       }
       private ManagementObject SmartDataInfo
       {
           get
           { 
              if(smartDataInfo==null)
              {
                  ManagementObject[] WMIData = DataRetriever.GetWMIData("ATAPI_SmartData");
                  smartDataInfo=WMIData[index];
              } 
              return smartDataInfo;         
           }
       }
       //property for getting the details of the hard disk
       //uses the private property to ensure that the management object for the  is only loaded when its needed
       public int Sectors{get{return (int)PhysicalMediaInfo["Sectors"]};};
       //Same for the smart data.  
       public int SomeSmartData{get{return (int)SmartDataInfo["SomeSmartData"]};};
