    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_SEARCH_INFO
    {
        public DHCP_SEARCH_INFO_TYPE SearchType;
        public ulong Complex;
    };
    
    public struct DHCP_SEARCH_INFO_WRAP
    {
       public DHCP_SEARCH_INFO_TYPE SearchType;
       private ulong Complex;
       
       public DHCP_IP_ADDRESS ClientIpAddress
       {
         get
         {
             return BitConverter.ToInt32(BitConverter.GetBytes(Complex),0);
         }
         set
         {
             byte[] orig = BitConverter.GetBytes(Complex);
             byte[] chng = BitConverter.GetBytes(value);
             Array.Copy(chng,0,orig,0,4);
 
         }
       }
       public DHCP_SEARCH_INFO_WRAP(ref DHCP_SEARCH_INFO var)
       {
          this.SearchType = var.SearchType;
          this.Complex = var.Complex;
          
       }
    
    };
