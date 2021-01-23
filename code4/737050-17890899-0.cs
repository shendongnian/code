    [DataContract]  
    public class NodeData {
      [DataMember]
      public int NodeID { get; set; }
      [DataMember]
      public int ParentID { get; set; }
      [DataMember]
      public int Index { get; set; }
      [DataMember]
      public string FriendlyName { get; set; }
    
      public NodeData(int nodeID, int parentID, int index, string friendlyName) {
        this.NodeID = nodeID;
        this.ParentID = parentID;
        this.Index = index;
        this.FriendlyName = friendlyName;
      }
    }
